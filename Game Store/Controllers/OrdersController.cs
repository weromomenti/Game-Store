using Business_Logic_Layer.Interfaces;
using Business_Logic_Layer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Game_Store.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
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
        [HttpGet("orderDetails")]
        public async Task<ActionResult> GetAllOrderDetailsAsync()
        {
            var orderDetails = await orderService.GetAllOrderDetailsAsync();
            return new OkObjectResult(orderDetails);
        }
        [Authorize(Policy = "ElevatedRights")]
        [HttpGet("orderDetails/{id}")]
        public async Task<ActionResult> GetOrderDetailsByIdAsync(int id)
        {
            var orderDetails = await orderService.GetOrderDetailsByIdAsync(id);
            return new OkObjectResult(orderDetails);
        }
        [Authorize(Policy = "StandardRights")]
        [HttpPost]
        public async Task<ActionResult> AddOrderAsync([FromBody] OrderModel order)
        {
            await orderService.AddAsync(order);
            return new OkResult();
        }
        [Authorize(Policy = "ElevatedRights")]
        [HttpPut]
        public async Task<ActionResult> UpdateOrderAsync([FromBody] OrderModel orderModel)
        {
            await orderService.UpdateAsync(orderModel);
            return new OkResult();
        }
        [Authorize(Policy = "ElevatedRights")]
        [HttpPost("orderDetails")]
        public async Task<ActionResult> AddOrderDetailsAsync([FromBody] OrderDetailsModel orderDetails)
        {
            await orderService.AddOrderDetailsAsync(orderDetails);
            return new OkObjectResult(orderDetails);
        }
        [Authorize(Policy = "StandardRights")]
        [HttpPut("addGame/{orderId}/{gameId}")]
        public async Task<ActionResult> AddGameAsync(int orderId, int gameId)
        {
            var order = await orderService.AddGameAsync(orderId, gameId);
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
        [Authorize(Policy = "ElevatedRights")]
        [HttpDelete("orderDetails/{id}")]
        public async Task<ActionResult> DeleteOrderDetailsAsync(int id)
        {
            await orderService.DeleteOrderDetailsAsync(id);
            return new OkResult();
        }
        [Authorize(Policy = "StandardRights")]
        [HttpPut("checkout/{orderId}")]
        public async Task<ActionResult<OrderModel>> CheckoutAsync(int orderId)
        {
            var order = await orderService.CheckoutAsync(orderId);
            return new OkObjectResult(order);
        }
    }
}
