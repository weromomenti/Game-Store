using Business_Logic_Layer.Interfaces;
using Business_Logic_Layer.Models;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Policy = "ElevatedRights")]
        [HttpGet]
        public async Task<ActionResult> GetAllOrdersAsync()
        {
            var orders = await orderService.GetAllAsync();
            return new OkObjectResult(orders);
        }
        [Authorize(Policy = "StandardRights")]
        [HttpGet("sum/{id}")]
        public async Task<ActionResult> GetSumAsync(int id)
        {
            decimal sum = await orderService.ToPayAsync(id);
            return new OkObjectResult(sum);
        }
        [Authorize(Policy = "ElevatedRights")]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetOrderByIdAsync(int id)
        {
            var order = await orderService.GetByIdAsync(id);
            return new OkObjectResult(order);
        }
        [Authorize(Policy = "ElevatedRights")]
        [HttpPost("{id}")]
        public async Task<ActionResult> UpdateOrderAsync(int id, [FromBody] OrderModel orderModel)
        {
            await orderService.UpdateAsync(orderModel);
            return new OkResult();
        }
        [Authorize(Policy = "StandardRights")]
        [HttpPut("addGame/{id}/{gameId}")]
        public async Task<ActionResult> AddGameAsync(int id, int gameId)
        {
            var order = await orderService.AddGameAsync(id, gameId);
            return new OkObjectResult(order);
        }
        [Authorize(Policy = "StandardRights")]
        [HttpPut("removeGame/{id}/{gameId}")]
        public async Task<ActionResult> RemoveGameAsync(int id, int gameId)
        {
            await orderService.RemoveGameAsync(id, gameId);
            return new OkResult();
        }
        [Authorize(Policy = "ElevatedRights")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrderAsync(int id)
        {
            await orderService.DeleteAsync(id);
            return new OkResult();
        }
    }
}
