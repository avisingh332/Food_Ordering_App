using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingApp.Business.Dtos.Request
{
    public class MenuPostRequestDto
    {

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string DishName { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public Decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
