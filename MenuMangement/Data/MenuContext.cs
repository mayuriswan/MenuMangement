using MenuMangement.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MenuMangement.API.Data
{
    public class MenuContext : DbContext
    {
        public MenuContext(DbContextOptions<MenuContext> options) : base(options) { }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure one-to-one relationship between Restaurant and Menu
            modelBuilder.Entity<Restaurant>()
                .HasOne(r => r.Menu)
                .WithOne(m => m.Restaurant)
                .HasForeignKey<Restaurant>(r => r.MenuId);

            // Configure one-to-many relationship between Menu and Categories
            modelBuilder.Entity<Menu>()
                .HasMany(m => m.Categories)
                .WithOne(c => c.Menu)
                .HasForeignKey(c => c.MenuId);

            // Configure one-to-many relationship between Category and MenuItems
            modelBuilder.Entity<Category>()
                .HasMany(c => c.MenuItems)
                .WithOne(mi => mi.Category)
                .HasForeignKey(mi => mi.CategoryId);

            // Seed data
            modelBuilder.Entity<Menu>().HasData(
                new Menu { Id = 1, Name = "Lunch Menu", RestaurantId = 1 },
                new Menu { Id = 2, Name = "Dinner Menu", RestaurantId = 2 }
            );

            modelBuilder.Entity<Restaurant>().HasData(
                new Restaurant { Id = 1, Name = "Sample Restaurant 1", LogoUrl = "https://my.menulogy.at/images/logo/client2/Kopie%20von%20Ohne%20Titel%20(900%20x%20128%20px)%20(600%20x%20128%20px)%20(400%20x%20128%20px)%20(1).png", MenuId = 1 },
                new Restaurant { Id = 2, Name = "Sample Restaurant 2", LogoUrl = "https://my.menulogy.at/images/logo/client2/Kopie%20von%20Ohne%20Titel%20(900%20x%20128%20px)%20(600%20x%20128%20px)%20(400%20x%20128%20px)%20(1).png", MenuId = 2 }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Homemade Drinks", MenuId = 1 },
                new Category { Id = 2, Name = "Guten Morgen!", MenuId = 1 },
                new Category { Id = 3, Name = "Getränke", MenuId = 1 },
                new Category { Id = 4, Name = "im Brot", MenuId = 1 },
                new Category { Id = 5, Name = "aus dem Ofen", MenuId = 1 },
                new Category { Id = 6, Name = "für den Anfang", MenuId = 1 },
                new Category { Id = 7, Name = "Salate", MenuId = 1 },
                new Category { Id = 8, Name = "etwas kleines", MenuId = 1 },
                new Category { Id = 9, Name = "aus der Pfanne", MenuId = 1 },
                new Category { Id = 10, Name = "mein Grill", MenuId = 1 },
                new Category { Id = 11, Name = "Holzkohlengrill", MenuId = 1 },
                new Category { Id = 12, Name = "etwas Süßes?", MenuId = 1 }
            );

            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem { Id = 1, Name = "Eistee Grüner Apfel", Description = "Hausgemachte Eistee, grüner Apfel Sirup, Minze", Price = 4.90m, PictureUrl = "https://my.menulogy.at/images/menu/client2/product-1625749094.png", CategoryId = 1 },
                new MenuItem { Id = 2, Name = "Eistee Wassermelone", Description = "Hausgemachte Eistee, Wassermelone Sirup, Minze", Price = 4.90m, PictureUrl = "https://my.menulogy.at/images/menu/client2/product-1647878278.png", CategoryId = 1 },
                new MenuItem { Id = 3, Name = "Eistee Maracuja", Description = "Hausgemachte Eistee, Maracuja Sirup, Minze", Price = 4.90m, PictureUrl = "https://my.menulogy.at/images/menu/client2/product-1625749342.png", CategoryId = 1 },
                new MenuItem { Id = 4, Name = "Eistee Erdbeere", Description = "Hausgemachte Eistee, Erdbeer Sirup, Minze", Price = 4.90m, PictureUrl = "https://my.menulogy.at/images/menu/client2/product-1625749715.png", CategoryId = 1 },
                new MenuItem { Id = 5, Name = "Eistee Beerentraum", Description = "Hausgemachte Eistee, Waldbeeren Sirup, Minze und Waldbeeren", Price = 4.90m, PictureUrl = "https://my.menulogy.at/images/menu/client2/product-1707155060.png", CategoryId = 1 },
                new MenuItem { Id = 6, Name = "Ayran 0,25l", Description = "Ayran 0,5l 4,90.-\nJoghurt, Wasser und Salz", Price = 2.90m, PictureUrl = "https://my.menulogy.at/images/menu/client2/product-1625748930.png", CategoryId = 1 }
            );
        }

    }
}
