using FoodOrderingApp.Business.Dtos.Request;
using FoodOrderingApp.Business.Dtos.Response;
using FoodOrderingApp.Business.Extensions;
using FoodOrderingApp.Business.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace FoodOrderingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        [HttpPost]
        public async Task<ActionResult<ReviewGetResponseDto>> CreateReviewAsync([FromBody] ReviewPostRequestDto request)
        {
            var userId = User.GetUserId() ?? throw new UnauthorizedAccessException();
            var response = await _reviewService.AddReviewAsync(request, userId);
            return Ok(response);
        }
    }
}
