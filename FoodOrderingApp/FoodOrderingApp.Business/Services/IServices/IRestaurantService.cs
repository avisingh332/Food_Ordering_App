using FoodOrderingApp.Business.Dtos.Request;
using FoodOrderingApp.Business.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingApp.Business.Services.IServices
{
    public interface IRestaurantService
    {
        //Task<RestaurantGetResponseDto> GetOwnerRestaurantAsync(string userId);
        Task<IEnumerable<RestaurantGetResponseDto>> GetAllRestaurantsAsync(string userId, string roles);
        Task<RestaurantGetResponseDto> CreateRestaurantAsync(RestaurantPostRequestDto restaurantPostRequest, string userId);
        Task<RestaurantGetResponseDto> GetRestaurantById(Guid restaurantId,string roles);
        Task<IEnumerable<RestaurantGetResponseDto>> SearchRestaurantsAsync(string? searchString = null);
        Task<RestaurantGetResponseDto> UpdateRestaurantAsync(Guid restaurantId, RestaurantPostRequestDto restaurantPutRequest);
    }
}
