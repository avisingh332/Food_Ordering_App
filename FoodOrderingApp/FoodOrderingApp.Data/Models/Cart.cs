using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingApp.Data.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
        [Required]
        public string UserId { get; set;}
        [ForeignKey("Retaurant")]
        public Guid RestaurantId { get; set; }
        public ApplicationUser User { get; set; }
        //navigation property
        public Restaurant Restaurant { get; set; }
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
