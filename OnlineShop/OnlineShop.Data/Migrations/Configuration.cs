using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineShop.Models.EntityModels;

namespace OnlineShop.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OnlineShop.Data.OnlineShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(OnlineShop.Data.OnlineShopContext context)
        {
            if (!context.Roles.Any(role => role.Name == "Client"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("Client");
                manager.Create(role);
            }

            if (!context.Roles.Any(role => role.Name == "Editor"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("Editor");
                manager.Create(role);
            }

            if (!context.Roles.Any(role => role.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("Admin");
                manager.Create(role);
            }

            if (!context.Roles.Any(role => role.Name == "ShopAssistant "))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("ShopAssistant ");
                manager.Create(role);
            }

            context.Products.AddOrUpdate(product => product.Name, new Product[]
            {
                new Product()
                {
                    Name = "Mouse Genius Super Fast",
                    Amount = 1,
                    Description = "Middle class gaming mouse",
                    Price = 30m,
                    Picture = "Mouse Genius Super Fast.jpg"
                },
                new Product()
                {
                    Name = "Mouse Uniko",
                    Amount = 3,
                    Description = "Low class gaming mouse",
                    Price = 15m,
                    Picture = "Mouse Uniko.jpg"
                },
                new Product()
                {
                    Name = "Mouse Sifico",
                    Amount = 0,
                    Description = "Elegant office mouse.",
                    Price = 12.5m,
                    Picture = "Mouse Sifico.jpg"
                },
                new Product()
                {
                    Name = "Headphones Logitech",
                    Amount = 10,
                    Description = "Best for rock music.",
                    Price = 32.75m,
                    Picture = "Headphones Logitech.jpg"
                },
                new Product()
                {
                    Name = "Keyboard Logitech 102",
                    Amount = 5,
                    Description = "Light and fast.",
                    Price = 75m,
                    Picture = "Keyboard Logitech 102.png"
                }



            });

        }
    }
}
