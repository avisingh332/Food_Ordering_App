using FoodOrderingApp.Business.Dtos.Request;
using FoodOrderingApp.Business.Dtos.Response;
using FoodOrderingApp.Business.Services.IServices;
using FoodOrderingApp.Data;
using FoodOrderingApp.Data.Models;
using FoodOrderingApp.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
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
        private readonly ApplicationDbContext _db;
        public RestaurantService(IRestaurantRepository restaurantRepository, IMenuRepository menuRepository, ApplicationDbContext db)
        {
            _restaurantRepository = restaurantRepository;
            _menuRepository = menuRepository;
            
            _db = db;
        }

        public async Task<IEnumerable<RestaurantGetResponseDto>> GetAllRestaurantsAsync(string userId, string roles)
        {
            IEnumerable<Restaurant> restaurants   = new List<Restaurant>();
            if (roles.Contains("RestaurantOwner"))
            {
                //restaurants = await _restaurantRepository.GetAllAsync(r => r.OwnerId == userId, includeProperties: "Owner,Menus,Orders,Reviews");
                restaurants = await _db.Restaurants.Where(r => r.OwnerId == userId)
                    .Include(r => r.Owner)
                    .Include(r => r.Menus)
                    .Include(r => r.Orders)
                        .ThenInclude(o => o.OrderItems)
                            .ThenInclude(oi => oi.Menu)
                    .Include(r=>r.Reviews)
                    .ToListAsync();
                //foreach( var restaurant in restaurants)
                //{
                //    foreach(var order in restaurant.Orders)
                //    {
                //        var updatedOrder  = await _orderRepository.GetAsync(o => order.Id == o.Id, includeProperties: "OrderItems");
                //        order.OrderItems = updatedOrder.OrderItems;
                //    }
                //}
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
            //var addedRestaurant =await  _restaurantRepository.GetAsync(r => r.Id == restaurantId, includeProperties: "Menus,Owner");
           var addedRestaurant =  await _db.Restaurants.Where(r => r.Id == restaurantId)
                    .Include(r => r.Owner)
                    .Include(r => r.Menus)
                    .Include(r => r.Orders)
                        .ThenInclude(o => o.OrderItems)
                            .ThenInclude(oi => oi.Menu)
                    .Include(r => r.Reviews)
                    .FirstOrDefaultAsync();
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

        public async Task<IEnumerable<RestaurantGetResponseDto>> SearchRestaurantsAsync(string? searchString = null)
        {
            IEnumerable<Restaurant> result =  await _restaurantRepository.SearchRestaurantAsync(searchString);
            IEnumerable<RestaurantGetResponseDto> response = result.Select(r =>
            {
                return new RestaurantGetResponseDto(r);
            });
            return response;
        }


        public async Task<RestaurantGetResponseDto> UpdateRestaurantAsync(Guid restaurantId, RestaurantPostRequestDto restaurantPutRequest)
        {
            // Retrieve the restaurant entity
            var restaurant = await _restaurantRepository.GetAsync(r => r.Id == restaurantId, includeProperties: "Menus");
            if (restaurant == null)
            {
                throw new KeyNotFoundException("Restaurant not found.");
            }

            // Update restaurant details
            restaurant.Name = restaurantPutRequest.Name;
            restaurant.Location = restaurantPutRequest.Location;
            restaurant.Cuisine = restaurantPutRequest.Cuisine;
            restaurant.ImageUrl = restaurantPutRequest.ImageUrl;
            //restaurant.UpdatedAt = DateTime.Now;

            // Update existing menus and add new menus if any
            foreach (var menuDto in restaurantPutRequest.Menus)
            {
                if (menuDto.Id.HasValue)
                {
                    var existingMenu = restaurant.Menus.FirstOrDefault(m => m.Id == menuDto.Id);
                    if (existingMenu != null)
                    {
                        // Update existing menu
                        existingMenu.DishName = menuDto.DishName;
                        existingMenu.Price = menuDto.Price;
                        existingMenu.ImageUrl = menuDto.ImageUrl;
                        existingMenu.UpdatedAt = DateTime.Now;
                    }

                }
                else
                {
                    // Add new menu
                    var newMenu = new Menu
                    {
                        Id = Guid.NewGuid(),
                        RetaurantId = restaurantId,
                        DishName = menuDto.DishName,
                        Price = menuDto.Price,
                        ImageUrl = menuDto.ImageUrl,
                        UpdatedAt = DateTime.Now,
                    };
                    await _menuRepository.AddAsync(newMenu);
                }
            }

            await _restaurantRepository.UpdateAsync(restaurant);

            //var updatedRestaurant = await _restaurantRepository.GetAsync(r => r.Id == restaurantId, includeProperties: "Menus,Owner");
            var updatedRestaurant = await _db.Restaurants.Where(r => r.Id == restaurantId)
                    .Include(r => r.Owner)
                    .Include(r => r.Menus)
                    .Include(r => r.Orders)
                        .ThenInclude(o => o.OrderItems)
                            .ThenInclude(oi => oi.Menu)
                    .Include(r => r.Reviews)
                    .FirstOrDefaultAsync();
            var response = new RestaurantGetResponseDto(updatedRestaurant);
            return response;
        }
    }
}
