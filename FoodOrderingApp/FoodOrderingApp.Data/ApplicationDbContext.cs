using FoodOrderingApp.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingApp.Data
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) : base(opt)
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            string customerId1 = Guid.NewGuid().ToString();
            string customerId2= Guid.NewGuid().ToString();
            string ownerId1 = Guid.NewGuid().ToString();
            string ownerId2 = Guid.NewGuid().ToString();
            //Password Hasher
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.HasData(
                     new ApplicationUser
                     {
                         Id = customerId1,
                         FullName = "Customer 1",
                         UserName = "customer1@test.com",
                         Email = "customer1@test.com",
                         NormalizedEmail = "customer1@test.com".ToUpper(),
                         NormalizedUserName = "customer1@test.com".ToUpper(),
                         PasswordHash = hasher.HashPassword(null, "string")
                     },
                     new ApplicationUser
                     {
                         Id = customerId2,
                         FullName = "Customer 2",
                         UserName = "customer2@test.com",
                         NormalizedUserName = "customer2@test.com".ToUpper(),
                         Email = "customer2@test.com",
                         NormalizedEmail = "customer2@test.com".ToUpper(),
                         PasswordHash = hasher.HashPassword(null, "string")
                     },
                     new ApplicationUser
                     {
                         Id = ownerId1,
                         FullName = "Owner 1",
                         UserName = "owner1@test.com",
                         NormalizedUserName = "owner1@test.com".ToUpper(),
                         Email = "owner1@test.com",
                         NormalizedEmail = "owner1@test.com".ToUpper(),
                         PasswordHash = hasher.HashPassword(null, "string")
                     },
                     new ApplicationUser
                     {
                         Id = ownerId2,
                         FullName = "Owner 2",
                         UserName = "owner2@test.com",
                         NormalizedUserName = "owner2@test.com".ToUpper(),
                         Email = "owner2@test.com",
                         NormalizedEmail = "owner2@test.com".ToUpper(),
                         PasswordHash = hasher.HashPassword(null, "string")
                     }
                );
            });

            var adminRoleId = "80ee5384-80a7-4aac-b4c8-b80b7dd25ac1";
            var restaurantOwnerRoleId = "1a0d5c4c-6b0e-4b7b-8b5e-4a3d6c5c7b8a";
            var customerRoleId = "95cb1e1c-d8b6-45a2-b240-6d211c06fd00";

            var roles = new List<IdentityRole>
            {
                new IdentityRole()
                {
                    Id = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper(),
                    ConcurrencyStamp = adminRoleId
                },
                new IdentityRole()
                {
                    Id = restaurantOwnerRoleId,
                    Name  = "RestaurantOwner",
                    NormalizedName = "RestaurantOwner".ToUpper(),
                    ConcurrencyStamp = restaurantOwnerRoleId
                },
                new IdentityRole()
                {
                    Id = customerRoleId,
                    Name  = "Customer",
                    NormalizedName = "Customer".ToUpper(),
                    ConcurrencyStamp = customerRoleId
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);

            var assignRoles = new List<IdentityUserRole<string>>()
            {
                new()
                {
                    UserId = customerId1,
                    RoleId = customerRoleId
                },
                new()
                {
                    UserId = customerId2,
                    RoleId = customerRoleId
                },
                new()
                {
                    UserId = ownerId1,
                    RoleId = restaurantOwnerRoleId
                },
                new()
                {
                    UserId = ownerId2,
                    RoleId = restaurantOwnerRoleId
                },

            };
            builder.Entity<IdentityUserRole<string>>().HasData(assignRoles);

            builder.Entity<Order>(entity =>
            {
                entity.HasOne(o=> o.User)
                .WithMany(u=> u.Orders)
                .HasForeignKey(o=> o.UserId)
                .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(o => o.Restaurant)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.RestaurantId)
                .OnDelete(DeleteBehavior.Restrict);
            });
            builder.Entity<OrderItem>(entity =>
            {
                builder.Entity<CartItem>()
                .HasOne(ci => ci.Menu)
                .WithMany()
                .HasForeignKey(ci => ci.DishId)
                .OnDelete(DeleteBehavior.Restrict);
            });
            builder.Entity<Review>(entity =>
            {
                entity.HasOne(r => r.Restaurant)
                .WithMany(r => r.Reviews)
                .HasForeignKey(r => r.RestaurantId)
                .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(r => r.Customer)
                .WithMany()
                .HasForeignKey(r => r.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
            });
            builder.Entity<Cart>(entity =>
            {
                entity.HasOne(r => r.Restaurant)
                .WithMany()
                .HasForeignKey(r => r.RestaurantId)
                .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
