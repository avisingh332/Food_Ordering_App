using FoodOrderingApp.Business.Dtos.Request;
using FoodOrderingApp.Business.Dtos.Response;
using FoodOrderingApp.Business.Services.IServices;
using FoodOrderingApp.Data;
using FoodOrderingApp.Data.Models;
using FoodOrderingApp.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingApp.Business.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMenuRepository _menuRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ApplicationDbContext _db;
        public RestaurantService(IRestaurantRepository restaurantRepository, IMenuRepository menuRepository, ApplicationDbContext db, IOrderRepository orderRepository)
        {
            _restaurantRepository = restaurantRepository;
            _menuRepository = menuRepository;

            _db = db;
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<RestaurantGetResponseDto>> GetAllRestaurantsAsync(string userId, string roles)
        {
            IEnumerable<Restaurant> restaurants = new List<Restaurant>();
            if (roles.Contains("RestaurantOwner"))
            {
                //restaurants = await _restaurantRepository.GetAllAsync(r => r.OwnerId == userId, includeProperties: "Owner,Menus,Orders,Reviews");
                restaurants = await _db.Restaurants.Where(r => r.OwnerId == userId)
                    .Include(r => r.Owner)
                    .Include(r => r.Menus)
                    .Include(r => r.Orders).ThenInclude(or => or.User)
                    .Include(r => r.Orders).ThenInclude(or => or.OrderItems)
                    .Include(res => res.Reviews).ThenInclude(rew => rew.ChildReviews)
                    .Include(r => r.Reviews).ThenInclude(r => r.Customer)
                    .ToListAsync();
                //restaurants = await _db.Restaurants.Where(r => r.OwnerId == userId)
                //   .Include(r => r.Owner)
                //   .Include(r => r.Menus)
                //   .Include(r => r.Orders).ThenInclude(or => or.User)
                //   .Include(r => r.Orders).ThenInclude(or => or.OrderItems)
                //   .Select(rec => { 
                //    return new Restaurant { 
                //    }
                //   })
                //   .ToListAsync();
                foreach (var res in restaurants)
                {
                    foreach (var menu in res.Menus)
                    {
                        menu.Restaurant = null;
                    }
                    foreach (var order in res.Orders)
                    {
                        order.Restaurant = null;
                        foreach (var oi in order.OrderItems)
                        {
                            oi.Menu.Restaurant = null;
                        }
                    }
                    foreach (var review in res.Reviews)
                    {
                        if (review.ParentId != null)
                        {
                            res.Reviews.Remove(review);
                        }
                        else if (review.ChildReviews.Any())
                        {
                            foreach (var childR in review.ChildReviews)
                            {
                                if (childR.ParentId != review.Id)
                                {
                                    review.ChildReviews.Remove(childR);
                                }
                            }
                        }
                    }
                    //res.Reviews =  res.Reviews.Where(r => r.ParentId == null).ToList();
                }
            }
            else
            {
                restaurants = await _restaurantRepository.GetAllAsync(includeProperties: "Owner,Menus,Reviews");
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
            foreach (var menu in restaurantPostRequest.Menus)
            {
                var menuToBeAdded = new Menu
                {
                    Id = Guid.NewGuid(),
                    RestaurantId = restaurantId,
                    DishName = menu.DishName,
                    Price = menu.Price,
                    ImageUrl = menu.ImageUrl,
                    UpdatedAt = DateTime.Now,
                };
                await _menuRepository.AddAsync(menuToBeAdded);
            }
            //var addedRestaurant =await  _restaurantRepository.GetAsync(r => r.Id == restaurantId, includeProperties: "Menus,Owner");
            var addedRestaurant = await _db.Restaurants.Where(r => r.Id == restaurantId)
                     .Include(r => r.Owner)
                     .Include(r => r.Menus)
                     .Include(r => r.Orders)
                         .ThenInclude(o => o.OrderItems)
                             .ThenInclude(oi => oi.Menu)
                     .Include(r => r.Reviews)
                     .FirstOrDefaultAsync();

            foreach (var menu in restaurant.Menus)
            {
                menu.Restaurant = null;
            }
            foreach (var order in restaurant.Orders)
            {
                order.Restaurant = null;
                foreach (var oi in order.OrderItems)
                {
                    oi.Menu.Restaurant = null;
                }
            }
            var response = new RestaurantGetResponseDto(addedRestaurant);
            return response;
        }

        public async Task<RestaurantGetResponseDto> GetRestaurantById(Guid restaurantId, string roles)
        {
            Restaurant restaurant = null;
            if (roles.Contains("RestaurantOwner"))
            {
                restaurant = await _restaurantRepository.GetAsync(r => r.Id == restaurantId, includeProperties: "Owner,Menus,Orders,Reviews");

                foreach (var menu in restaurant.Menus)
                {
                    menu.Restaurant = null;
                }
                foreach (var order in restaurant.Orders)
                {
                    order.Restaurant = null;
                    foreach (var oi in order.OrderItems)
                    {
                        oi.Menu.Restaurant = null;
                    }
                }

               
            }
            else
            {
                restaurant = await _db.Restaurants
                 .Include(r => r.Owner)
                 .Include(r => r.Menus)
                 .Include(r => r.Reviews)
                     .ThenInclude(r => r.Customer)
                 .Include(r => r.Reviews)
                     .ThenInclude(r => r.ChildReviews)
                 .FirstOrDefaultAsync();

                
                foreach (var menu in restaurant.Menus)
                {
                    menu.Restaurant = null;
                }
                
            }
            // filtering the data
            foreach (var review in restaurant.Reviews)
            {
                if (review.ParentId != null)
                {
                    restaurant.Reviews.Remove(review);
                }
                else if (review.ChildReviews.Any())
                {
                    foreach (var childR in review.ChildReviews)
                    {
                        if (childR.ParentId != review.Id)
                        {
                            review.ChildReviews.Remove(childR);
                        }
                    }
                }
            }
            var response = new RestaurantGetResponseDto(restaurant);
            return response;

        }

        public async Task<IEnumerable<RestaurantGetResponseDto>> SearchRestaurantsAsync(string? searchString = null)
        {
            IEnumerable<Restaurant> result = await _restaurantRepository.SearchRestaurantAsync(searchString);
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
                        RestaurantId = restaurantId,
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
            foreach (var menu in restaurant.Menus)
            {
                menu.Restaurant = null;
            }
            foreach (var order in restaurant.Orders)
            {
                order.Restaurant = null;
                foreach (var oi in order.OrderItems)
                {
                    oi.Menu.Restaurant = null;
                }
            }
            var response = new RestaurantGetResponseDto(updatedRestaurant);
            return response;
        }
    }
}
