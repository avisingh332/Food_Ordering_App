using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodOrderingApp.Data.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace FoodOrderingApp.Business.Dtos.Response
{
    public class ReviewGetResponseDto
    {
        public Guid Id { get; set; }
        public string ReviewText { get; set; }
        public int Rating { get; set; }

        public string CustomerId { get; set; }
        public Guid RestaurantId { get; set; }
  

        public UserGetResponseDto? Customer { get; set; }
 

        public DateTime CreatedAt { get; set; }
        
        public Guid? ParentId { get; set; }
        public ICollection<ReviewGetResponseDto> ChildReviews { get; set; } = new List<ReviewGetResponseDto>();

        public ReviewGetResponseDto(Review review)
        {
            this.Id = review.Id;
            this.ReviewText = review.ReviewText;
            this.Rating = review.Rating;
            this.CustomerId = review.CustomerId;
            this.RestaurantId = review.RestaurantId;
            this.CreatedAt = review.CreatedAt;
            this.ParentId = review.ParentId;
            if (review.Customer!=null)
            {
                this.Customer = new UserGetResponseDto(review.Customer);
            }
            if(review.ChildReviews!= null && review.ChildReviews.Count>0)
            {
                foreach(var child in review.ChildReviews)
                {
                    this.ChildReviews.Add(new ReviewGetResponseDto(child));
                }
            }
        }

    }
}
