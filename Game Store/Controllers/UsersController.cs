using Business_Logic_Layer.Interfaces;
using Business_Logic_Layer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Game_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
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
