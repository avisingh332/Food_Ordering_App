using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingApp.Data.Models
{
    public class Restaurant
    {
        
        public Guid Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; }

        [ForeignKey("Owner")]
        [Required]
        public string OwnerId { get; set; }

        public ApplicationUser Owner { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Location { get; set; }

        [Required]
        public DateTime RegisterationTimeStamp {get; set;}

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Cuisine { get; set; }

        public string ImageUrl { get; set; }
        
        public ICollection<Menu> Menus { get; set; }
        public ICollection<Order>? Orders { get; set; }
        
        public ICollection<Review>? Reviews { get; set; }

    }
}
