using FoodOrderingApp.Business.Dtos.Request;
using FoodOrderingApp.Business.Dtos.Response;
using FoodOrderingApp.Business.Extensions;
using FoodOrderingApp.Business.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrderingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<RestaurantGetResponseDto>>> GetAllRestaurantsAsync()
        {
            var userId = User.GetUserId();
            var roles = User.GetRole();
            var response = await _restaurantService.GetAllRestaurantsAsync(userId, roles);
            return Ok(response);
        }
        [HttpPost]
        [Authorize(Roles = "RestaurantOwner")]
        public async Task<ActionResult<RestaurantGetResponseDto>> RegisterRestaurantAsync([FromBody] RestaurantPostRequestDto restaurantPostRequest)
        {
            var userId = User.GetUserId() ?? throw new UnauthorizedAccessException();
            var response = await _restaurantService.CreateRestaurantAsync(restaurantPostRequest, userId);
            return Ok(response);
        }

        [HttpGet]
        [Authorize]
        [Route("{id}")]
        public async Task<ActionResult<RestaurantGetResponseDto>> GetRestaurantById([FromRoute] Guid id)
        {
            var userId = User.GetUserId();
            var roles = User.GetRole();
            var response = await _restaurantService.GetRestaurantById(id, roles);
            return Ok(response);
        }
    }
}
