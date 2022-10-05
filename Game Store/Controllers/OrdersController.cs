using Business_Logic_Layer.Interfaces;
using Business_Logic_Layer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Game_Store.Controllers
{
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllOrdersAsync()
        {
            var orders = await orderService.GetAllAsync();
            return new OkObjectResult(orders);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetOrderByIdAsync(int id)
        {
            var order = await orderService.GetByIdAsync(id);
            return new OkObjectResult(order);
        }
        [HttpPost("{id}")]
        public async Task<ActionResult> UpdateOrderAsync(int id, [FromBody] OrderModel orderModel)
        {
            await orderService.UpdateAsync(orderModel);
            return new OkResult();
        }
        [HttpPut("addGame/{id}/{gameId}")]
        public async Task<ActionResult> AddGameAsync(int id, int gameId)
        {
            await orderService.AddGameAsync(id, gameId);
            return new OkResult();
        }
        [HttpPut("removeGame/{id}/{gameId}")]
        public async Task<ActionResult> RemoveGameAsync(int id, int gameId)
        {
            await orderService.RemoveGameAsync(id, gameId);
            return new OkResult();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrderAsync(int id)
        {
            await orderService.DeleteAsync(id);
            return new OkResult();
        }
    }
}
