using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodOrderingApp.Data.Models;

namespace FoodOrderingApp.Business.Dtos.Response
{
    public class RestaurantGetResponseDto
    {
        public Guid Id { get; set; }
       
        public string Name { get; set; }

        public string OwnerId { get; set; }

        public UserGetResponseDto Owner { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Location { get; set; }

        [Required]
        public DateTime RegisteredAt { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Cuisine { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<MenuGetResponseDto> Menus { get; set; }
        public ICollection<OrderGetResponseDto>? Orders { get; set; }

        public ICollection<ReviewGetResponseDto>? Reviews { get; set; }
        public RestaurantGetResponseDto(Restaurant restaurant)
        {
            this.Id = restaurant.Id;
            this.Cuisine = restaurant.Cuisine;
            this.ImageUrl = restaurant.ImageUrl;
            this.Location = restaurant.Location;
            this.Name = restaurant.Name;
            this.RegisteredAt = restaurant.RegisterationTimeStamp;
            this.Menus = new List<MenuGetResponseDto>();
            this.Orders = new List<OrderGetResponseDto>();
            this.Reviews = new List<ReviewGetResponseDto>();
            if (restaurant.Owner != null)
            {
                this.Owner = new UserGetResponseDto(restaurant.Owner);
            }
            if(restaurant.Menus != null)
            {
                foreach (var menu in restaurant.Menus)
                {
                    this.Menus.Add(new MenuGetResponseDto(menu));
                }
            }
            if(restaurant.Orders != null)
            {
                foreach(var order in restaurant.Orders)
                {
                    this.Orders.Add(new OrderGetResponseDto(order));
                }
            }
        }
    }
}
