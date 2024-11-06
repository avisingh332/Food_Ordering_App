using FoodOrderingApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingApp.Data.Repository.IRepository
{
    public interface ICartItemRepository : IRepository<CartItem>
    {
        //Task<CartItem> GetCustomerCartItem(Expression<Func<CartItem, bool>> filter);
        Task UpdateAsync(CartItem item);
    }
}
