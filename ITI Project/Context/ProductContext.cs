using ITI_Project.Models;
using Microsoft.EntityFrameworkCore;
namespace ITI_Project.Context
{
    public class ProductContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=DESKTOP-KC0GJDU;Database=DBStore;Trusted_Connection=True;Encrypt=false");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            var categories = new List<Category>
            {
                new Category { CategoryId = 1, Name = "Electronics", Description = "Devices and gadgets" },
                new Category { CategoryId = 2, Name = "Clothing", Description = "Apparel and accessories" },
                new Category { CategoryId = 3, Name = "Books", Description = "Various genres of books" },
                new Category { CategoryId = 4, Name = "Home & Kitchen", Description = "Household items and kitchenware" }
            };


            var products = new List<Product>
            {
                new Product { ProductId = 1, Title = "Smartphone", Price = 299.99, Description = "Latest model smartphone", Quantity = 50,ImagePath = "images/Smartphone.jpg", CategoryId = 1 },
                new Product { ProductId = 2, Title = "Laptop", Price = 799.99, Description = "High performance laptop", Quantity = 30,ImagePath="~/images/laptop.jpg", CategoryId = 1 },
                new Product { ProductId = 3, Title = "Bluetooth Headphones", Price = 99.99, Description = "Noise-cancelling headphones", Quantity = 75,ImagePath="~/images/Headphone.jpg", CategoryId = 1 },
                new Product { ProductId = 4, Title = "Winter Jacket", Price = 129.99, Description = "Warm winter jacket", Quantity = 40,ImagePath="~/images/Jacket.jpg", CategoryId = 2 },
                new Product { ProductId = 5, Title = "Running Shoes", Price = 89.99, Description = "Comfortable running shoes", Quantity = 60,ImagePath="~/images/running-shoes.jpg", CategoryId = 2 },
                new Product { ProductId = 6, Title = "Novel", Price = 14.99, Description = "Bestselling novel", Quantity = 100,ImagePath="~/images/Novel.jpg", CategoryId = 3 },
                new Product { ProductId = 7, Title = "Cookbook", Price = 24.99, Description = "Delicious recipes for home cooking", Quantity = 50,ImagePath="~/images/cookbook.jpg", CategoryId = 3 },
                new Product { ProductId = 8, Title = "Coffee Maker", Price = 49.99, Description = "Automatic coffee maker", Quantity = 20,ImagePath="~/images/Coffe.jpg", CategoryId = 4 },
                new Product { ProductId = 9, Title = "Air Fryer", Price = 79.99, Description = "Healthy cooking with less oil", Quantity = 25,ImagePath="~/images/airfryer.jpg", CategoryId = 4 },
                new Product { ProductId = 10, Title = "Blender", Price = 59.99, Description = "Powerful kitchen blender", Quantity = 30,ImagePath="~/images/blender.jpg", CategoryId = 4 }
            };

            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<Product>().HasData(products);
        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
