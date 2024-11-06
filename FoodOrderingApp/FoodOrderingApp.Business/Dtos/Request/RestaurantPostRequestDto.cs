using FoodOrderingApp.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingApp.Business.Dtos.Request
{
    public class RestaurantPostRequestDto
    {
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; }


        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Location { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Cuisine { get; set; }

        public string ImageUrl { get; set; }
        public ICollection<MenuPostRequestDto> Menus { get; set; }

    }
}
