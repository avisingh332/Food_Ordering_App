using FoodOrderingApp.Business.Dtos.Request;
using FoodOrderingApp.Business.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingApp.Business.Services.IServices
{
    public interface ICartService
    {
        Task<CartGetResponseDto> GetCustomerCartAsync(string userId);
        Task<CartGetResponseDto> AddCartItemAsync(CartItemPostRequestDto request,string userId);
    }
}
