using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingApp.Data.Models
{
    public class Review
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string ReviewText { get; set; }
        [Required]
        [Range(1,5)]
        public int Rating { get; set; }

        // foreign keys
        [ForeignKey("Customer")]
        [Required]
        public string CustomerId { get; set; }
        [ForeignKey("Restaurant")]
        [Required]
        public Guid RestaurantId { get; set; }

        public Guid? ParentId { get; set; }

        //navigation Property 
        public ApplicationUser Customer { get; set; }
        public Restaurant Restaurant { get; set; }

        public Review ParentReview { get; set; }

        public ICollection<Review> ChildReviews { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }

    }
}
