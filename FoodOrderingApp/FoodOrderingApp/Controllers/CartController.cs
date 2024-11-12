using FoodOrderingApp.Business.Dtos.Request;
using FoodOrderingApp.Business.Dtos.Response;
using FoodOrderingApp.Business.Extensions;
using FoodOrderingApp.Business.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace FoodOrderingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<CartGetResponseDto?>> GetCartAsync()
        {
            var userId = User.GetUserId() ?? throw new UnauthorizedAccessException();
            var response =await _cartService.GetCustomerCartAsync(userId);
            return Ok(response);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CartGetResponseDto>> UpsertCartAsync([FromBody] CartItemPostRequestDto request)
        {
            string userId = User.GetUserId() ??throw new UnauthorizedAccessException();
            var response = await _cartService.AddCartItemAsync(request, userId);
            return Ok(response);
        }
    }
}
