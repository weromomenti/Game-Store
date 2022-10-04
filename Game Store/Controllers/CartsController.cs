using Business_Logic_Layer.Interfaces;
using Business_Logic_Layer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Game_Store.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartService cartService;

        public CartsController(ICartService cartService)
        {
            this.cartService = cartService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartModel>>> GetAllCartsAsync()
        {
            var carts = await cartService.GetAllAsync();
            return new OkObjectResult(carts);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CartModel>> GetCartByIdAsync(int id)
        {
            var cart = await cartService.GetByIdAsync(id);
            return new OkObjectResult(cart);
        }
        [HttpPost("{id}")]
        public async Task<ActionResult> UpdateCartAsync(int id, [FromBody] CartModel cartModel)
        {
            await cartService.UpdateAsync(cartModel);
            return new OkResult();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCartAsync(int id)
        {
            await cartService.DeleteAsync(id);
            return new OkResult();
        }
    }
}
