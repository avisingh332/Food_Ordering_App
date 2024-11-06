using FoodOrderingApp.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingApp.Business.Dtos.Response
{
    public class CartItemGetResponseDto
    {
        public Guid Id { get; set; }
       
        public Guid CartId { get; set; }
        public Guid DishId { get; set; }

        public int Quantity { get; set; }

        public MenuGetResponseDto Menu { get; set; }
        public CartItemGetResponseDto(CartItem item)
        {
            this.Id = item.Id;
            this.CartId = item.CartId;
            this.Quantity = item.Quantity;
            this.DishId = item.DishId;
            if (item.Menu != null)
            {
                this.Menu = new MenuGetResponseDto(item.Menu);
            }
        }
    }
}
