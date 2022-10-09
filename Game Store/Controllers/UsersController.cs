using Business_Logic_Layer.Interfaces;
using Business_Logic_Layer.Models;
using Data_Layer.Entities;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IAuthenticationService authenticationService;

        public UsersController(IUserService userService, IAuthenticationService authenticationService)
        {
            this.userService = userService;
            this.authenticationService = authenticationService;
        }
        [Authorize(Policy = "ElevatedRights")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetAllUsersAsync()
        {
            var users = await userService.GetAllAsync();
            return new OkObjectResult(users);
        }
        [Authorize(Policy = "ElevatedRights")]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetUserByIdAsync(int id)
        {
            var user = await userService.GetByIdAsync(id);
            return new OkObjectResult(user);
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var response = await authenticationService.LoginAsync(request);
            return Ok(response);
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var response = await authenticationService.RegisterAsync(request);

            return Ok(response);
        }
        [Authorize(Policy = "ElevatedRights")]
        [HttpPut]
        public async Task<ActionResult> UpdateUserAsync(int id, [FromBody] UserModel userModel)
        {
            await userService.UpdateAsync(userModel);
            return new OkResult();
        }
        [Authorize(Policy = "ElevatedRights")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await userService.DeleteAsync(id);
            return new OkResult();
        }
    }
}
