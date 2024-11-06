using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingApp.Business.Dtos.Response
{
    public class ReviewGetResponseDto
    {
        public Guid Id { get; set; }
        public string ReviewText { get; set; }
        public int Rating { get; set; }

        public string CustomerId { get; set; }
        public Guid RestaurantId { get; set; }
        public Guid DishId { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
