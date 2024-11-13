using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingApp.Business.Dtos.Request
{
    public class ReviewPostRequestDto
    {
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string ReviewText { get; set; }
        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        [Required]
        public Guid RestaurantId { get; set; }

        public Guid? ParentReviewId { get; set; }
    }
}
