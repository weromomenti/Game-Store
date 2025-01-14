﻿using AutoMapper;
using Business_Logic_Layer.Interfaces;
using Business_Logic_Layer.Models;
using Data_Layer.Entities;
using Data_Layer.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfiguration configuration;
        private readonly IUnitOfWork unitOfWork;

        public AuthenticationService(UserManager<IdentityUser> userManager, IConfiguration configuration, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.unitOfWork = unitOfWork;
        }
        public async Task<string> LoginAsync(LoginRequest request)
        {
            var user = await userManager.FindByNameAsync(request.Username);

            if (user is null)
            {
                user = await userManager.FindByEmailAsync(request.Username);
            }
            if (user is null || !await userManager.CheckPasswordAsync(user, request.Password))
            {
                throw new ArgumentException($"Unable to authenticate user {request.Username}");
            }
            var userInfo = await unitOfWork.UserRepository.GetByUserNameAsync(request.Username);

            var authClaims = new List<Claim>
            {
                new (ClaimTypes.Name, user.UserName),
                new (ClaimTypes.Email, user.Email),
                //new Claim("firstName", userInfo?.Person?.FirstName),
                //new Claim("lastName", userInfo?.Person?.LastName),
                //new Claim("avatar", userInfo?.Avatar),
                //new Claim("birth", userInfo?.Person?.BirthDate.ToString()),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            var userRoles = await userManager.GetRolesAsync(user);

            authClaims.AddRange(userRoles.Select(userRole => new Claim(ClaimTypes.Role, userRole)));

            var token = GetToken(authClaims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public async Task<string> RegisterAsync(RegisterRequest request)
        {
            var userByEmail = await userManager.FindByEmailAsync(request.Email);
            var userByUsername = await userManager.FindByNameAsync(request.Username);

            if (userByEmail is not null || userByUsername is not null)
            {
                throw new ArgumentException($"User with email {request.Email} or username {request.Username} already exists.");
            }
            User user = new()
            {
                Person = new Person { FirstName = request.FirstName, LastName = request.LastName },
                Role = unitOfWork.RoleRepository.GetAllAsync().Result.FirstOrDefault(r => r.RoleName == "User"),
                IdentityUser = new IdentityUser
                {
                    Email = request.Email, 
                    UserName = request.Username, 
                    SecurityStamp = Guid.NewGuid().ToString()
                }
            };
            await unitOfWork.UserRepository.AddAsync(user);
            var result = await userManager.CreateAsync(user.IdentityUser, request.Password);
            await userManager.AddToRoleAsync(user.IdentityUser, "User");
            await unitOfWork.SaveChangesAsync();


            if (!result.Succeeded)
            {
                throw new ArgumentException($"Unable to register user {request.Username} error: {result.Errors}");
            }

            return await LoginAsync(new LoginRequest { Username = request.Email, Password = request.Password });
        }
        private JwtSecurityToken GetToken(IEnumerable<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

            return token;
        }

    }
}
