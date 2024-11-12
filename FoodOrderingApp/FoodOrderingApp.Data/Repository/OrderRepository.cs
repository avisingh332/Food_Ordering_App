using FoodOrderingApp.Data.Models;
using FoodOrderingApp.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingApp.Data.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public readonly ApplicationDbContext _db;
        public OrderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Order>> GetOrdersByRestaurantId(Guid restaurantId)
        {
            var query = _db.Orders.Where(o => o.RestaurantId == restaurantId)
                .Include(o => o.User)
                .Include(o => o.OrderItems);
            return await query.ToListAsync();
        }
        public async Task<IEnumerable<Order>> GetOrdersByUserId(string userId)
        {
            var query = _db.Orders.Where(o => o.UserId == userId)
                .Include(o => o.Restaurant)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Menu);
            return await query.ToListAsync();
        }
    }
}
