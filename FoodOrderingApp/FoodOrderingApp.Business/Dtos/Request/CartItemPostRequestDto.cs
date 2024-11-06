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
    public class CartItemPostRequestDto
    {
        [Required]
        public Guid CartId { get; set; }

        [Required]
        public Guid DishId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
