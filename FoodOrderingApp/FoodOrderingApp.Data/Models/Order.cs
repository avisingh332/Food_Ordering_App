using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingApp.Data.Models
{
    public enum OrderStatus
    {
        Placed, 
        Preparing, 
        Ready, 
        Delivered
    }
    public class Order
    {
        public Guid Id { get; set; }
        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [Required]
        [ForeignKey("Restaurant")]
        public Guid RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

        [Required]
        public OrderStatus OrderStatus { get; set; }
        public ICollection<OrderItem>? OrderItems { get; set; } = new List<OrderItem>();
        public DateTime CreatedAt { get; set; }

    }
}
