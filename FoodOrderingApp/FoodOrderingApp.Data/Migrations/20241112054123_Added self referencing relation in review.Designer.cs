﻿// <auto-generated />
using System;
using FoodOrderingApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FoodOrderingApp.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241112054123_Added self referencing relation in review")]
    partial class Addedselfreferencingrelationinreview
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FoodOrderingApp.Data.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "bbba5549-6df2-445f-bd59-e1d905e13a45",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "26c1fd83-9ef1-4636-b66b-10c0e92310e5",
                            Email = "customer1@test.com",
                            EmailConfirmed = false,
                            FullName = "Customer 1",
                            LockoutEnabled = false,
                            NormalizedEmail = "CUSTOMER1@TEST.COM",
                            NormalizedUserName = "CUSTOMER1@TEST.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEFOjzUDhV4jRW5XVapSXqPmqqwNnF7FKA5S1cdmF0ncXyuzMxbQjVNLP/SMZeBR3Xg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "db0589f4-9dcf-4e1b-8c80-b5a8a126db15",
                            TwoFactorEnabled = false,
                            UserName = "customer1@test.com"
                        },
                        new
                        {
                            Id = "927eb077-b79a-4d64-8e15-d44b0bf3cf3c",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6ade0067-d54b-4ac0-97f6-f4377befcd90",
                            Email = "customer2@test.com",
                            EmailConfirmed = false,
                            FullName = "Customer 2",
                            LockoutEnabled = false,
                            NormalizedEmail = "CUSTOMER2@TEST.COM",
                            NormalizedUserName = "CUSTOMER2@TEST.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEDIi0v30RfFrsypMsrO1IGpSGTr8wU8Zj+pF5gTZXBZ19uz+c1kTEQ2WLWKIetpgCQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "48f1dbd9-7b69-4288-a7de-762743b22e51",
                            TwoFactorEnabled = false,
                            UserName = "customer2@test.com"
                        },
                        new
                        {
                            Id = "463338bd-5e4b-427d-aece-c0187e47dd4a",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7874247c-9409-42af-8257-7a84a126c0cc",
                            Email = "owner1@test.com",
                            EmailConfirmed = false,
                            FullName = "Owner 1",
                            LockoutEnabled = false,
                            NormalizedEmail = "OWNER1@TEST.COM",
                            NormalizedUserName = "OWNER1@TEST.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEADmjdfMIBKOnFz8QfSlf9PeRatKdCQwOB52RswzoVPUKvn+S0QfP3b1Z9u5iY1M+g==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "8e5f898f-3f27-4804-b0fd-3f742f3b798e",
                            TwoFactorEnabled = false,
                            UserName = "owner1@test.com"
                        },
                        new
                        {
                            Id = "8e3ddce3-7364-429e-b371-aee8df68b31b",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c7cb16e9-c077-4c1c-b0e5-7ab049ed6674",
                            Email = "owner2@test.com",
                            EmailConfirmed = false,
                            FullName = "Owner 2",
                            LockoutEnabled = false,
                            NormalizedEmail = "OWNER2@TEST.COM",
                            NormalizedUserName = "OWNER2@TEST.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEIzMThSyvJTambXWxI7fxVqtvBT4GyFcEu+WmnUwDsy1vDfsCxnSOFNSTULSAOQNiQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "e51a61a7-e3b9-464f-9715-189510b0fe69",
                            TwoFactorEnabled = false,
                            UserName = "owner2@test.com"
                        });
                });

            modelBuilder.Entity("FoodOrderingApp.Data.Models.Cart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RestaurantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("FoodOrderingApp.Data.Models.CartItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DishId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("DishId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("FoodOrderingApp.Data.Models.Menu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DishName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<Guid>("RestaurantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("FoodOrderingApp.Data.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<Guid>("RestaurantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("FoodOrderingApp.Data.Models.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MenuId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("FoodOrderingApp.Data.Models.Restaurant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cuisine")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OwnerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("RegisterationTimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId")
                        .IsUnique();

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("FoodOrderingApp.Data.Models.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("DishId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<Guid>("RestaurantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ReviewText")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DishId");

                    b.HasIndex("ParentId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "80ee5384-80a7-4aac-b4c8-b80b7dd25ac1",
                            ConcurrencyStamp = "80ee5384-80a7-4aac-b4c8-b80b7dd25ac1",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "1a0d5c4c-6b0e-4b7b-8b5e-4a3d6c5c7b8a",
                            ConcurrencyStamp = "1a0d5c4c-6b0e-4b7b-8b5e-4a3d6c5c7b8a",
                            Name = "RestaurantOwner",
                            NormalizedName = "RESTAURANTOWNER"
                        },
                        new
                        {
                            Id = "95cb1e1c-d8b6-45a2-b240-6d211c06fd00",
                            ConcurrencyStamp = "95cb1e1c-d8b6-45a2-b240-6d211c06fd00",
                            Name = "Customer",
                            NormalizedName = "CUSTOMER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "bbba5549-6df2-445f-bd59-e1d905e13a45",
                            RoleId = "95cb1e1c-d8b6-45a2-b240-6d211c06fd00"
                        },
                        new
                        {
                            UserId = "927eb077-b79a-4d64-8e15-d44b0bf3cf3c",
                            RoleId = "95cb1e1c-d8b6-45a2-b240-6d211c06fd00"
                        },
                        new
                        {
                            UserId = "463338bd-5e4b-427d-aece-c0187e47dd4a",
                            RoleId = "1a0d5c4c-6b0e-4b7b-8b5e-4a3d6c5c7b8a"
                        },
                        new
                        {
                            UserId = "8e3ddce3-7364-429e-b371-aee8df68b31b",
                            RoleId = "1a0d5c4c-6b0e-4b7b-8b5e-4a3d6c5c7b8a"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("FoodOrderingApp.Data.Models.Cart", b =>
                {
                    b.HasOne("FoodOrderingApp.Data.Models.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FoodOrderingApp.Data.Models.ApplicationUser", "User")
                        .WithOne("Cart")
                        .HasForeignKey("FoodOrderingApp.Data.Models.Cart", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FoodOrderingApp.Data.Models.CartItem", b =>
                {
                    b.HasOne("FoodOrderingApp.Data.Models.Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodOrderingApp.Data.Models.Menu", "Menu")
                        .WithMany()
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Menu");
                });

            modelBuilder.Entity("FoodOrderingApp.Data.Models.Menu", b =>
                {
                    b.HasOne("FoodOrderingApp.Data.Models.Restaurant", "Restaurant")
                        .WithMany("Menus")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("FoodOrderingApp.Data.Models.Order", b =>
                {
                    b.HasOne("FoodOrderingApp.Data.Models.Restaurant", "Restaurant")
                        .WithMany("Orders")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FoodOrderingApp.Data.Models.ApplicationUser", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Restaurant");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FoodOrderingApp.Data.Models.OrderItem", b =>
                {
                    b.HasOne("FoodOrderingApp.Data.Models.Menu", "Menu")
                        .WithMany()
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodOrderingApp.Data.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("FoodOrderingApp.Data.Models.Restaurant", b =>
                {
                    b.HasOne("FoodOrderingApp.Data.Models.ApplicationUser", "Owner")
                        .WithOne("Restaurant")
                        .HasForeignKey("FoodOrderingApp.Data.Models.Restaurant", "OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("FoodOrderingApp.Data.Models.Review", b =>
                {
                    b.HasOne("FoodOrderingApp.Data.Models.ApplicationUser", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FoodOrderingApp.Data.Models.Menu", "Menu")
                        .WithMany("Reviews")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodOrderingApp.Data.Models.Review", "ParentReview")
                        .WithMany("ChildReviews")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FoodOrderingApp.Data.Models.Restaurant", "Restaurant")
                        .WithMany("Reviews")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Menu");

                    b.Navigation("ParentReview");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("FoodOrderingApp.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FoodOrderingApp.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodOrderingApp.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("FoodOrderingApp.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodOrderingApp.Data.Models.ApplicationUser", b =>
                {
                    b.Navigation("Cart");

                    b.Navigation("Orders");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("FoodOrderingApp.Data.Models.Cart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("FoodOrderingApp.Data.Models.Menu", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("FoodOrderingApp.Data.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("FoodOrderingApp.Data.Models.Restaurant", b =>
                {
                    b.Navigation("Menus");

                    b.Navigation("Orders");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("FoodOrderingApp.Data.Models.Review", b =>
                {
                    b.Navigation("ChildReviews");
                });
#pragma warning restore 612, 618
        }
    }
}