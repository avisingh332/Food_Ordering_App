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
    public class MenuGetResponseDto
    {
        public Guid Id { get; set; }
        public Guid RetaurantId { get; set; }
        public RestaurantGetResponseDto Restaurant { get; set; }

        public string DishName { get; set; }

        public Decimal Price { get; set; }

        public string ImageUrl { get; set; }
        public DateTime UpdatedAt { get; set; }

        public MenuGetResponseDto(Menu menu)
        {
            this.Id = menu.Id;
            this.RetaurantId = menu.RetaurantId;
            this.DishName = menu.DishName;
            this.Price = menu.Price;
            this.ImageUrl = menu.ImageUrl;
            this.UpdatedAt = menu.UpdatedAt;       
        }
    }
}
