using FoodOrderingApp.Data.Models;
using FoodOrderingApp.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingApp.Data.Repository
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        private readonly ApplicationDbContext _db;
        public CartRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<Cart> GetCartAsync(Expression<Func<Cart, bool>> filter)
        {

            IQueryable<Cart> query = _db.Carts;
            if (query != null) query = query.Where(filter);
           
            query = query.Include(c=> c.Restaurant).Include(c=> c.CartItems).ThenInclude(ci => ci.Menu);

            Cart result = await query.FirstOrDefaultAsync();

            return result;
        }
    }
}
