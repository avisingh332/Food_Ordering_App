using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingApp.Data.Models
{
    public class OrderItem
    {
        public Guid Id { get; set; }

        [ForeignKey("Order")]
        [Required]
        public Guid OrderId { get; set; }
        [ForeignKey("Menu")]
        [Required]
        public Guid MenuId { get; set; }

        [Required]
        [Range(1,10)]
        public int Quantity { get; set; }

        // Navigation properties
        public Menu Menu { get; set; }
        public Order Order { get; set; }
    }
}
