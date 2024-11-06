using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodOrderingApp.Data.Models;

namespace FoodOrderingApp.Business.Dtos.Response
{
    public class OrderGetResponseDto
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public UserGetResponseDto User { get; set; }

        public Guid RestaurantId { get; set; }
        public RestaurantGetResponseDto Restaurant { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public ICollection<OrderItemGetResponseDto>? OrderItems { get; set; }
        public DateTime CreatedAt { get; set; }

        public OrderGetResponseDto(Order order)
        {
            this.Id = order.Id;
            this.UserId = order.UserId;
            this.RestaurantId = order.RestaurantId;
            this.OrderStatus = order.OrderStatus;
            this.CreatedAt = order.CreatedAt;
            this.OrderItems = new List<OrderItemGetResponseDto>();
            if (order.User != null)
            {
                this.User = new UserGetResponseDto(order.User);
            }
            if(order.Restaurant != null)
            {
                this.Restaurant = new RestaurantGetResponseDto(order.Restaurant);
            }
            if (order.OrderItems != null)
            {
                foreach(var item in order.OrderItems)
                {
                    this.OrderItems.Add(new OrderItemGetResponseDto(item));
                }
            }
        }
    }
}
