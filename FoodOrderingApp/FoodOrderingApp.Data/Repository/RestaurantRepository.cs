using FoodOrderingApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using FoodOrderingApp.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingApp.Data.Repository
{
    public class RestaurantRepository : Repository<Restaurant>, IRestaurantRepository
    {
        private readonly ApplicationDbContext _db;
        public RestaurantRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Restaurant>> SearchRestaurantAsync(string? searchString)
        {

            if (string.IsNullOrEmpty(searchString))
            {
                return new List<Restaurant>();
            }

            var query = _db.Restaurants
                .Where(r => r.Name.Contains(searchString) ||
                            r.Cuisine.Contains(searchString) ||
                            r.Location.Contains(searchString));

            return await query.ToListAsync();
        }

    }
}
