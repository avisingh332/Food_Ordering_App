using FoodOrderingApp.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingApp.Business.Dtos.Response
{
    public class CartGetResponseDto
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public UserGetResponseDto User { get; set; }
        public ICollection<CartItemGetResponseDto> CartItems { get; set; } = new List<CartItemGetResponseDto>();

        public CartGetResponseDto(Cart cart)
        {
            this.Id = cart.Id;
            this.UserId = cart.UserId;
            if(cart.User != null)
            {
                this.User = new UserGetResponseDto(cart.User);
            }
            if(cart.CartItems != null && cart.CartItems.Count>0)
            {
                foreach(var item in cart.CartItems)
                {
                    this.CartItems.Add(new CartItemGetResponseDto(item));
                }
            }
        }
    }
}
