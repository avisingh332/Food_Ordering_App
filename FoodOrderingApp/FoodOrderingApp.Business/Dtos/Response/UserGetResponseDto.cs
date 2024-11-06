using FoodOrderingApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingApp.Business.Dtos.Response
{
    public class UserGetResponseDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public UserGetResponseDto(ApplicationUser user)
        {
            this.Id = user.Id;
            this.Name = user.FullName;
            this.Email = user.Email;
        }
    }
}
