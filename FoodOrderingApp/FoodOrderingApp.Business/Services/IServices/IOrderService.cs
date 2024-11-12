using FoodOrderingApp.Business.Dtos.Response;
using FoodOrderingApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingApp.Business.Services.IServices
{
    public interface IOrderService
    {
        Task<OrderGetResponseDto> AddOrderAsync(Guid cartId, string userId);
        Task<IEnumerable<OrderGetResponseDto>> GetOrdersByUserId(string userId);
        Task<IEnumerable<OrderGetResponseDto>> GetOrdersByRestaurantId(Guid restaurantId);
        Task<OrderGetResponseDto> UpdateOrderStatusAsync(Guid orderId, OrderStatus updatedStatus);
    }
}
