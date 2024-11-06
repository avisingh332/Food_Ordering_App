using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingApp.Data.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string FullName { get; set; }
        
        /// <summary>
        /// If user is Restaurant Owner then only He will have a Restaurant
        /// </summary>
        /// 

        public Restaurant? Restaurant { get; set; }
                
        /// <summary>
        /// if User is Customer then only he will have a cart
        /// </summary>

        public Cart? Cart { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
