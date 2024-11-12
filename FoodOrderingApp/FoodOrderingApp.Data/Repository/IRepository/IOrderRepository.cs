using FoodOrderingApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingApp.Data.Repository.IRepository
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByUserId(string userId);
        Task<IEnumerable<Order>> GetOrdersByRestaurantId(Guid restaurantId);
    }
}
