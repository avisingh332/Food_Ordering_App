using FoodOrderingApp.Business.Dtos.Response;
using FoodOrderingApp.Business.Extensions;
using FoodOrderingApp.Business.Services.IServices;
using FoodOrderingApp.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrderingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [Route("{cartId}")]
        public async Task<ActionResult<OrderGetResponseDto>> CreateOrderAsync([FromRoute] Guid cartId)
        {
            var userId = User.GetUserId() ?? throw new UnauthorizedAccessException();
            var response = await _orderService.AddOrderAsync(cartId, userId);
            return Ok(response);
        }

        [HttpGet]
        [Authorize(Roles ="RestaurantOwner")]
        [Route("Restaurant/{id}")]
        public async Task<ActionResult<IEnumerable<OrderGetResponseDto>>> GetOrderForRestaurant([FromRoute] Guid id)
        {
            var response = await _orderService.GetOrdersByRestaurantId(id);
            return Ok(response);
        }
        [HttpGet]
        [Authorize(Roles = "Customer")]
        [Route("Customer")]
        public async Task<ActionResult<IEnumerable<OrderGetResponseDto>>> GetOrderForCustomer()
        {
            var userId = User.GetUserId() ?? throw new UnauthorizedAccessException();
            var response = await _orderService.GetOrdersByUserId(userId);
            return Ok(response);
        }

        [HttpPut]
        [Authorize(Roles = "RestaurantOwner")]
        [Route("{id}/OrderStatus")]
        public async Task<ActionResult<OrderGetResponseDto>> UpdateOrderStatus([FromRoute] Guid id, [FromBody] OrderStatus orderStatus) 
        {
            var response = await _orderService.UpdateOrderStatusAsync(id, orderStatus);
            return Ok(response);
        }
    }
}
