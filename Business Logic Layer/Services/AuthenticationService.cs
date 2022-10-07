using AutoMapper;
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
        private readonly UserManager<UserIdentity> userManager;
        private readonly IConfiguration configuration;
        private readonly IUnitOfWork unitOfWork;

        public AuthenticationService(UserManager<UserIdentity> userManager, IConfiguration configuration, IMapper mapper, IUnitOfWork unitOfWork)
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

            var authClaims = new List<Claim>
            {
                new (ClaimTypes.Name, user.UserName),
                new (ClaimTypes.Email, user.Email),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

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

            UserIdentity identity = new()
            {
                Email = request.Email,
                UserName = request.Username,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            User user = new()
            {
                Person = new Person { FirstName = request.FirstName, LastName = request.LastName },
                Role = unitOfWork.RoleRepository.GetAllAsync().Result.FirstOrDefault(r => r == 1),
                Identity = identity
            };

            var result = await userManager.CreateAsync(identity, request.Password);
            await unitOfWork.UserRepository.AddAsync(user);
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
