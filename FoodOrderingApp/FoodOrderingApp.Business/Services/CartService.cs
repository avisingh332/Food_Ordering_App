using FoodOrderingApp.Business.Dtos.Request;
using FoodOrderingApp.Business.Dtos.Response;
using FoodOrderingApp.Business.Services.IServices;
using FoodOrderingApp.Data.Models;
using FoodOrderingApp.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
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
        public async Task<CartGetResponseDto?> GetCustomerCartAsync(string userId)
        {
            
            var cart = await _cartRepository.GetCartAsync(c => c.UserId == userId);
            if (cart == null)
            {
                return null;
            }
            else
            {
                return new CartGetResponseDto(cart);
            }
        }

        public async Task<CartGetResponseDto> AddCartItemAsync(CartItemPostRequestDto request, string userId)
        {
            var cart = await _cartRepository.GetAsync(c => c.UserId == userId, includeProperties:"CartItems");
            if(cart == null)
            {
                var id = Guid.NewGuid();
                await _cartRepository.AddAsync(new Cart
                {
                    Id = id,
                    UserId = userId,
                    RestaurantId = request.RestaurantId
                });
                await _cartItemRepository.AddAsync(new CartItem
                {
                    Id = Guid.NewGuid(),
                    CartId = id,
                    DishId = request.DishId,
                    Quantity = request.Quantity
                });
                cart = await _cartRepository.GetAsync(c => c.UserId == userId, includeProperties:"CartItems");
            }

            else if ( request.RestaurantId != cart.RestaurantId)
            {
                // Clear cart for older restaurant
                await _cartItemRepository.RemoveRangeAsync(cart.CartItems);
                await _cartRepository.RemoveAsync(cart);

                // Add a new cart for new Restaurant 
                var id = Guid.NewGuid();
                await _cartRepository.AddAsync(new Cart
                {
                    Id = id,
                    UserId = userId,
                    RestaurantId = request.RestaurantId
                });
                await _cartItemRepository.AddAsync(new CartItem
                {
                    Id = Guid.NewGuid(),
                    CartId = id,
                    DishId = request.DishId,
                    Quantity = request.Quantity
                });

                cart = await _cartRepository.GetAsync(c=> c.Id == id);
            }
            else
            {
                //if cart is not present then seed a new cart
                if (cart == null)
                {
                    var id = Guid.NewGuid();
                    await _cartRepository.AddAsync(new Cart
                    {
                        Id = id,
                        UserId = userId,
                        RestaurantId = request.RestaurantId
                    });
                }
                // Cart item to add is for existing restaurant cart
                var cartItem = await _cartItemRepository.GetAsync(ci => ci.CartId == cart.Id && ci.DishId == request.DishId);

                if (cartItem != null)
                {
                    cartItem.Quantity += request.Quantity;
                    if (cartItem.Quantity == 0)
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
                        CartId = cart.Id,
                        DishId = request.DishId,
                        Quantity = request.Quantity
                    });
                }
                cart = await _cartRepository.GetAsync(c => c.Id == cart.Id);
            }
            return new CartGetResponseDto(cart);
        }
    }
}
