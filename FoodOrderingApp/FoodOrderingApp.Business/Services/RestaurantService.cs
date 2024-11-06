using FoodOrderingApp.Business.Dtos.Request;
using FoodOrderingApp.Business.Dtos.Response;
using FoodOrderingApp.Business.Services.IServices;
using FoodOrderingApp.Data.Models;
using FoodOrderingApp.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingApp.Business.Services
{
    public class RestaurantService: IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMenuRepository _menuRepository;
        public RestaurantService(IRestaurantRepository restaurantRepository, IMenuRepository menuRepository)
        {
            _restaurantRepository = restaurantRepository;
            _menuRepository = menuRepository;
        }

        public async Task<IEnumerable<RestaurantGetResponseDto>> GetAllRestaurantsAsync(string userId, string roles)
        {
            IEnumerable<Restaurant> restaurants   = new List<Restaurant>();
            if (roles.Contains("RestaurantOwner"))
            {
                restaurants = await _restaurantRepository.GetAllAsync(r => r.OwnerId == userId, includeProperties: "Owner,Menus,Orders,Reviews");
            }
            else
            {
                restaurants = await _restaurantRepository.GetAllAsync(includeProperties: "Owner,Menus");
            }
            var response = restaurants.Select(r => new RestaurantGetResponseDto(r));
            return response;
        }

        public async Task<RestaurantGetResponseDto> CreateRestaurantAsync(RestaurantPostRequestDto restaurantPostRequest, string userId)
        {
            var restaurantId = Guid.NewGuid();
            var restaurant = new Restaurant
            {
                Id = restaurantId,
                Name = restaurantPostRequest.Name,
                Location = restaurantPostRequest.Location,
                Cuisine = restaurantPostRequest.Cuisine,
                OwnerId = userId,
                ImageUrl = restaurantPostRequest.ImageUrl
            };
            await _restaurantRepository.AddAsync(restaurant);
            foreach(var menu in restaurantPostRequest.Menus)
            {
                var menuToBeAdded = new Menu
                {
                    Id = Guid.NewGuid(),
                    RetaurantId = restaurantId,
                    DishName = menu.DishName,
                    Price = menu.Price,
                    ImageUrl = menu.ImageUrl,
                    UpdatedAt = DateTime.Now,
                };
                await _menuRepository.AddAsync(menuToBeAdded);
            }
            var addedRestaurant =await  _restaurantRepository.GetAsync(r => r.Id == restaurantId, includeProperties: "Menus,Owner");
            var response = new RestaurantGetResponseDto(addedRestaurant);
            return response;
        }

        public async Task<RestaurantGetResponseDto> GetRestaurantById(Guid restaurantId,  string roles)
        {

            if (roles.Contains("RestaurantOwner"))
            {
                var restaurant =await  _restaurantRepository.GetAsync(r => r.Id == restaurantId,includeProperties:"Owner,Menus,Orders,Reviews");
                var response = new RestaurantGetResponseDto(restaurant);
                return response;
            }
            else
            {
                var restaurant = await _restaurantRepository.GetAsync(r => r.Id == restaurantId, includeProperties: "Owner,Menus,Reviews");
                var response = new RestaurantGetResponseDto(restaurant);
                return response;
            }
            
        }
    }
}
