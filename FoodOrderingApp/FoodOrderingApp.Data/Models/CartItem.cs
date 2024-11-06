using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingApp.Data.Models
{
    public class CartItem
    {
        public Guid Id { get; set; }
        [ForeignKey("Cart")]
        [Required]
        public Guid CartId { get; set; }

        [ForeignKey("Menu")]
        public Guid DishId { get; set; }

        [Required]
        [Range(1,10)]
        public int Quantity { get; set; }

        // navigation properties
        public Cart Cart { get; set; }
        public  Menu Menu { get; set; }

    }
}
