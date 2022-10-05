using Business_Logic_Layer.Interfaces;
using Business_Logic_Layer.Models;
using Data_Layer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Game_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService/*, UserManager<User> userManager*/)
        {
            this.userService = userService;
            //this.userManager = userManager;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetAllUsersAsync()
        {
            var users = await userService.GetAllAsync();
            return new OkObjectResult(users);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetUserByIdAsync(int id)
        {
            var user = await userService.GetByIdAsync(id);
            return new OkObjectResult(user);
        }
        [HttpPost("signIn")]
        /*public async Task<ActionResult<UserModel>> SignIn([FromBody] LoginModel loginModel)
        {
            var user = await userService.GetByUserNameAsync(loginModel.UserName);

            if (user == null || await userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                return Unauthorized();
            }
            var authClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("string"));
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(authClaims),
                Expires = DateTime.Now.AddMinutes(20),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new OkObjectResult(new
            {
                token = tokenHandler.WriteToken(token),
                expires = token.ValidTo
            });
        }*/
        [HttpPost]
        public async Task<ActionResult> UpdateUserAsync(int id, [FromBody] UserModel userModel)
        {
            await userService.UpdateAsync(userModel);
            return new OkResult();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await userService.DeleteAsync(id);
            return new OkResult();
        }
    }
}
