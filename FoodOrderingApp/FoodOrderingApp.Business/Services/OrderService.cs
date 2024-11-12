using FoodOrderingApp.Business.Dtos.Response;
using FoodOrderingApp.Business.Services.IServices;
using FoodOrderingApp.Data.Models;
using FoodOrderingApp.Data.Repository.IRepository;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingApp.Business.Services
{
    public class OrderService: IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        public OrderService(IOrderRepository orderRepository, ICartRepository cartRepository, IOrderItemRepository orderItemRepository)
        {
            _orderRepository = orderRepository;
            _cartRepository = cartRepository;
            _orderItemRepository = orderItemRepository;
        }
        public async Task<OrderGetResponseDto> AddOrderAsync(Guid cartId, string userId)
        {
            var cart = await _cartRepository.GetAsync( c=> c.Id == cartId, includeProperties:"CartItems");
            var orderId = Guid.NewGuid();
            var order = new Order
            {
                Id =orderId,
                RestaurantId = cart.RestaurantId,
                UserId = userId, 
                CreatedAt = DateTime.Now,
                OrderStatus = OrderStatus.Placed, 
            };
            await _orderRepository.AddAsync(order);
            var addedOrder = await _orderRepository.GetAsync(o => o.Id == orderId, includeProperties: "OrderItems");
            
            var orderItems = cart.CartItems.Select(ci => new OrderItem
            {
                Id = Guid.NewGuid(),
                OrderId = addedOrder.Id,
                MenuId = ci.DishId,
                Quantity = ci.Quantity
            }).ToList();
            foreach(var item in orderItems)
            {
                await _orderItemRepository.AddAsync(item);
            }
            await _cartRepository.RemoveAsync(cart);

            order = await _orderRepository.GetAsync(o => o.Id == orderId, includeProperties: "OrderItems");
            return new OrderGetResponseDto(order);
        }

        public async Task<IEnumerable<OrderGetResponseDto>> GetOrdersByRestaurantId(Guid restaurantId)
        {
            var orders = await _orderRepository.GetOrdersByRestaurantId(restaurantId);
            IEnumerable<OrderGetResponseDto> response = orders.Select(o => new OrderGetResponseDto(o));
            return response;
        }
        public async Task<IEnumerable<OrderGetResponseDto>> GetOrdersByUserId(string userId)
        {
            var orders = await _orderRepository.GetOrdersByUserId(userId);
            IEnumerable<OrderGetResponseDto> response = orders.Select(o => new OrderGetResponseDto(o));
            return response;
        }
        public async Task<OrderGetResponseDto> UpdateOrderStatusAsync(Guid orderId, OrderStatus updatedStatus)
        {
            var order = await _orderRepository.GetAsync(o => o.Id == orderId);
            order.OrderStatus = updatedStatus;
            await _orderRepository.UpdateAsync(order);
            order = await _orderRepository.GetAsync(o => o.Id == orderId);
            return new OrderGetResponseDto(order);

        }

    }
}
