using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingApp.Data.Models
{
    public class Menu
    {
        public Guid Id { get; set; }

        [Required]
        [ForeignKey("Restaurant")]
        public Guid RetaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

        [Required]
        [StringLength(50, MinimumLength =5)]
        public string DishName { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public Decimal Price { get; set; }

        public string ImageUrl { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<Review> Reviews { get; set; }
        
    }
}
