namespace HomeWork03_05_19.DataAccess.Migrations
{
    using HomeWork03_05_19.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HomeWork03_05_19.DataAccess.CartContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HomeWork03_05_19.DataAccess.CartContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.ProductTypes.AddRange(new List<ProductType>()
            {
                new ProductType() {Name = "Milk"},
                new ProductType() {Name = "Bread"},
                new ProductType() {Name = "Water"},
            });
            context.SaveChanges();

            context.Products.AddRange(new List<Product>()
            {
                new Product() { ProductType = context.ProductTypes.ToList()[0], Price = 250,
                    ProducedDate = Convert.ToDateTime("29.03.03"), ExpirationDate = Convert.ToDateTime("29.04.03")},
                new Product() { ProductType = context.ProductTypes.ToList()[1], Price = 350,
                    ProducedDate = Convert.ToDateTime("29.03.03"), ExpirationDate = Convert.ToDateTime("29.04.03")},
                new Product() { ProductType = context.ProductTypes.ToList()[2], Price = 450,
                    ProducedDate = Convert.ToDateTime("29.03.03"), ExpirationDate = Convert.ToDateTime("29.04.03")},
            });
            context.SaveChanges();
        }
    }
}
