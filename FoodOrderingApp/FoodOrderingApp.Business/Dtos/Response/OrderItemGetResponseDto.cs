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
    public class OrderItemGetResponseDto
    {
        public Guid Id { get; set; }

        public Guid OrderId { get; set; }

        public Guid MenuId { get; set; }

        public int Quantity { get; set; }

        public MenuGetResponseDto Menu { get; set; }

        public OrderItemGetResponseDto(OrderItem item)
        {
            this.Id = item.Id;
            this.OrderId = item.OrderId;
            this.MenuId = item.MenuId;
            this.Quantity = item.Quantity;
            if(item.Menu != null)
            {
                this.Menu = new MenuGetResponseDto(item.Menu);
            }
        }

    }
}
