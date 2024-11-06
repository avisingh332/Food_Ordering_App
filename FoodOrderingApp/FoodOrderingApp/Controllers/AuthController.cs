using FoodOrderingApp.Business.Dtos.Request;
using FoodOrderingApp.Business.Dtos.Response;
using FoodOrderingApp.Business.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrderingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authservice;
        public AuthController(IAuthService authService)
        {
            _authservice = authService;
        }
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<ResponseDto>> Login([FromBody] LoginRequestDto loginRequest)
        {
            ResponseDto response = null;
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponseDto
                {
                    IsSuccess = false,
                    Message = "Please Provide UserName and Password",
                    Result = null
                });
            }

            var loginResponse = await _authservice.Login(loginRequest);
            if (loginResponse == null)
            {
                response = new ResponseDto
                {
                    IsSuccess = false,
                    Message = "Login Failed Email or Password is Incorrect",
                    Result = null,
                };
            }
            else
            {
                response = new ResponseDto
                {
                    IsSuccess = true,
                    Message = "Login Success",
                    Result = loginResponse,
                };
            }

            return Ok(response);
        }
    }
}
