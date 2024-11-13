using FoodOrderingApp.Business.Dtos.Request;
using FoodOrderingApp.Business.Dtos.Response;
using FoodOrderingApp.Business.Services.IServices;
using FoodOrderingApp.Data.Models;
using FoodOrderingApp.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingApp.Business.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<ReviewGetResponseDto> AddReviewAsync(ReviewPostRequestDto reviewRequest, string userId)
        {
            var reviewId = Guid.NewGuid();
            var review = new Review
            {
                Id = reviewId,
                ParentId = reviewRequest.ParentReviewId,
                CustomerId = userId,
                Rating = reviewRequest.Rating,
                ReviewText = reviewRequest.ReviewText,
                CreatedAt = DateTime.Now,
                RestaurantId = reviewRequest.RestaurantId,
            };

            await _reviewRepository.AddAsync(review);
            var addedReview = await _reviewRepository.GetAsync(r => r.Id == reviewId, includeProperties:"Customer,ChildReviews");
            return new ReviewGetResponseDto(addedReview);
        }
    }
}
