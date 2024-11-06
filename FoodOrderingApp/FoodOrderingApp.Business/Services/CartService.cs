using FoodOrderingApp.Business.Dtos.Request;
using FoodOrderingApp.Business.Dtos.Response;
using FoodOrderingApp.Business.Services.IServices;
using FoodOrderingApp.Data.Models;
using FoodOrderingApp.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingApp.Business.Services
{
    public class CartService: ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICartItemRepository _cartItemRepository;
        public CartService(ICartRepository cartRepository, ICartItemRepository cartItemRepository)
        {
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
        }
        public async Task<CartGetResponseDto> GetCustomerCartAsync(string userId)
        {
            
            var cart = await _cartRepository.GetCartAsync(c => c.UserId == userId);
            if (cart == null)
            {
                await _cartRepository.AddAsync(new Cart
                {
                    UserId = userId,
                    Id = Guid.NewGuid(),
                });

                var cartAdded = await _cartRepository.GetCartAsync(c => c.UserId == userId);
                return new CartGetResponseDto(cartAdded);
            }
            else
            {
                return new CartGetResponseDto(cart);
            }
        }
        public async Task<CartGetResponseDto> AddCartItemAsync(CartItemPostRequestDto request)
        {

            var cartItem = await _cartItemRepository.GetAsync(ci=> ci.CartId == request.CartId && ci.DishId == request.DishId);
            if(cartItem != null)
            {
                cartItem.Quantity += request.Quantity;
                if(cartItem.Quantity == 0)
                {
                    await _cartItemRepository.RemoveAsync(cartItem);
                }
                else
                {
                    await _cartItemRepository.UpdateAsync(cartItem);
                }
            }
            else
            {
                await _cartItemRepository.AddAsync(new CartItem
                {
                    Id = Guid.NewGuid(),
                    CartId = request.CartId,
                    DishId = request.DishId,
                    Quantity = request.Quantity
                });
            }
            var cart = await _cartRepository.GetCartAsync(c => c.Id == request.CartId);
            return new CartGetResponseDto(cart);
        }
    }
}
