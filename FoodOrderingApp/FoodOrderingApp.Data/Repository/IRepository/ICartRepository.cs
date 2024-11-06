using FoodOrderingApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingApp.Data.Repository.IRepository
{
    public interface ICartRepository : IRepository<Cart>
    {
        Task<Cart> GetCartAsync(Expression<Func<Cart, bool>> filter);
    }
}
