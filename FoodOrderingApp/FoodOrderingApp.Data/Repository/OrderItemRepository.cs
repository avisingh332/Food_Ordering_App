using FoodOrderingApp.Data.Models;
using FoodOrderingApp.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingApp.Data.Repository
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
