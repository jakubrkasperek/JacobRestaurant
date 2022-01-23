using JacobRestaurant.Models;
using JacobRestaurant.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace JacobRestaurant
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Dish> Dishes { get; set; } 
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var adminRoleId = "C18ED0EB-3DA8-477B-8B45-3C03B91E67A3";

            AppUser firstUser = new AppUser()
            {
                Id = "D6771784-D825-46D8-A159-6714634D096F",
                FirstName = "Jakub",
                LastName = "Admin",
                Email = "admin@mail.com",
                UserName = "Admin",
                EmailConfirmed = true,
                NormalizedEmail = "ADMIN@MAIL.COM",
                NormalizedUserName = "ADMIN@MAIL.COM",
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var password = new PasswordHasher<AppUser>();
            var hashed = password.HashPassword(firstUser, "Admin12");
            firstUser.PasswordHash = hashed;

            modelBuilder.Entity<AppUser>().HasData(firstUser);
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string> { UserId = firstUser.Id, RoleId = adminRoleId });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = adminRoleId,
                Name = "Admin",
                NormalizedName = "ADMINISTRATOR"
            });


            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = 1,
                Name = "Burgers"
            });

            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = 2,
                Name = "Drinks"
            });

            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = 3,
                Name = "Desserts"
            });


            modelBuilder.Entity<Dish>().HasData(new Dish
            {
                DishId = 1,
                Name = "Big Burger",
                Description = "Very big burger",
                CategoryId = 1,
                Price = 9.99M,
                ImageUrl = "https://cdn.pixabay.com/photo/2020/10/05/19/55/hamburger-5630646_960_720.jpg",
            });

            modelBuilder.Entity<Dish>().HasData(new Dish
            {
                DishId = 2,
                Name = "Small Burger",
                Description = "Really small burger",
                CategoryId = 1,
                Price = 5.50M,
                ImageUrl = "https://cdn.pixabay.com/photo/2020/10/05/19/55/hamburger-5630646_960_720.jpg",
            });

            modelBuilder.Entity<Dish>().HasData(new Dish
            {
                DishId = 3,
                Name = "Chad Burger",
                Description = "Burger for giga chads",
                CategoryId = 1,
                Price = 21.37M,
                ImageUrl = "https://cdn.pixabay.com/photo/2020/10/05/19/55/hamburger-5630646_960_720.jpg",
            });

            modelBuilder.Entity<Dish>().HasData(new Dish
            {
                DishId = 4,
                Name = "Vegan Burger",
                Description = "Burger for vegans",
                CategoryId = 1,
                Price = 28.10M,
                ImageUrl = "https://cdn.pixabay.com/photo/2020/10/05/19/55/hamburger-5630646_960_720.jpg",
            });
           
            modelBuilder.Entity<Dish>().HasData(new Dish
            {
                DishId = 5,
                Name = "Tiramisu",
                Description = "Italian tiramisu",
                CategoryId = 3,
                Price = 8.50M,
                ImageUrl = "https://cdn.pixabay.com/photo/2017/10/28/19/07/tiramisu-2897900_960_720.jpg",
            });

            modelBuilder.Entity<Dish>().HasData(new Dish
            {
                DishId = 6,
                Name = "Ice-creams",
                Description = "Sweet and cold",
                CategoryId = 3,
                Price = 8.20M,
                ImageUrl = "https://cdn.pixabay.com/photo/2018/04/27/10/44/dessert-3354303_960_720.jpg",
            });

            modelBuilder.Entity<Dish>().HasData(new Dish
            {
                DishId = 7,
                Name = "Granita",
                Description = "It is worth a try",
                CategoryId = 3,
                Price = 8.10M,
                ImageUrl = "https://cdn.pixabay.com/photo/2015/09/23/17/01/ice-cream-954101_960_720.jpg",
            });

            modelBuilder.Entity<Dish>().HasData(new Dish
            {
                DishId = 8,
                Name = "Coffee",
                Description = "Just coffee",
                CategoryId = 2,
                Price = 6.99M,
                ImageUrl = "https://cdn.pixabay.com/photo/2019/01/16/22/37/coffee-3936903_960_720.jpg",
            });

            modelBuilder.Entity<Dish>().HasData(new Dish
            {
                DishId = 9,
                Name = "Tea",
                Description = "Just good tea",
                CategoryId = 2,
                Price = 6.99M,
                ImageUrl = "https://cdn.pixabay.com/photo/2017/03/01/05/12/tea-cup-2107599_960_720.jpg",
            });

            modelBuilder.Entity<Dish>().HasData(new Dish
            {
                DishId = 10,
                Name = "Water",
                Description = "Just water",
                CategoryId = 2,
                Price = 3.99M,
                ImageUrl = "https://cdn.pixabay.com/photo/2017/02/02/15/15/bottle-2032980_960_720.jpg",
            });

            modelBuilder.Entity<Dish>().HasData(new Dish
            {
                DishId = 11,
                Name = "Coca-Cola",
                Description = "Just Coca-Cola",
                CategoryId = 2,
                Price = 5.99M,
                ImageUrl = "https://cdn.pixabay.com/photo/2017/02/25/23/12/coca-cola-2099000_960_720.jpg",
            });
        }
    }
}
