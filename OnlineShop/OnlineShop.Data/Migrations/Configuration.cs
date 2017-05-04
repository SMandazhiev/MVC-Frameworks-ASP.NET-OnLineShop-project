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

       //   context.Comments.AddOrUpdate(comment=>comment.Title, new Comment[]
       //   {
       //       new Comment()
       //       {
       //           Title = "Kaby Lake Motherboards at $140: MSI Z270 SLI Plus vs. ASRock Z270 Killer SLI",
       //           Content = "Earlier this year, Intel released their latest Kaby Lake processors and the new Z270/H270 chipsets to accompany them. Myriads of motherboards based on these two chipsets have been released during these past couple of months, covering virtually all of the consumer market demand. In this review, we are having a look at two cost-effective Z270 motherboards that have been designed with gamers in mind - the MSI Z270 SLI Plus and the ASRock Z270 Killer SLI. As their names suggest, these two motherboards mainly place their marketing focus on the SLI support, and both have a retail price of under $140. We will examine their features, differences and performance in the following pages of this review. Other AnandTech Reviews for Intel’s 7th Generation CPUs and 200-Series Motherboards The Intel Core i7-7700K (91W) Review - CPU Review The Intel Core i5-7600K (91W) Review - CPU Review The Intel Core i3-7350K (60W) Review - CPU Review CPU Buyer's Guide: Q1 2017 - Guide In comparison to the older Z170 boards, the new Z270 board on the base specifications are hardly any different. The Z270 ones have four extra PCIe lanes configurable on the chipset, potentially new audio and new networking controllers, and Intel Optane Technology Support. Although four extra PCIe lanes does sound like a huge difference, it is an important upgrade for the implementation of native M.2 slots (on Z170-based motherboards, this usually meant disabling some other device/port on the motherboard). Also, note that Intel Optane drives should still function on other chipsets as drives; the Z270 only allows them to enable their “smart caching” technology."
       //       },  
       //       new Comment()
       //       {
       //           Title = "First Look: Samsung Galaxy S8",
       //           Content = "We first saw Samsung’s new 5.8-inch Galaxy S8 and 6.2-inch Galaxy S8+ at its Unpacked event a few weeks ago. During the event, we saw demos of its new virtual assistant, Bixby, and its DeX docking station, which allows the Galaxy S8 to provide a desktop-like experience by connecting to an external monitor and peripherals, but we didn’t have much time with the phones to do much more than take some pictures and try a couple of the new features. After receiving a Galaxy S8 earlier this week, we wanted to give you some feedback about its design and biometric features, as well as, an initial performance and battery life assessment before we dive into our usual in-depth testing. My biggest complaint about the design is the location of the fingerprint sensor, which I discuss in the video above. It has been relocated to the back next to the camera, making it difficult to reach and use. The new face unlock feature, the second of the S8’s three biometric authentication options, is flawed too. Despite my best efforts, I was not able to get face unlock to work, not even once. The feature, which relies solely on the front-facing camera for identification, also is not very secure, assuming it works at all. It has already been shown that simply holding a picture in front of the camera is enough to fool it into unlocking the phone. The camera really needs to be augmented with an infrared camera to detect a face’s heat signature as a liveness test, or a second, depth-sensing camera to at least detect a face in three dimensions. So far the iris scanner, which I also demo in the video above, has proven to be the easiest and most reliable biometric option."
       //       }    
       //   });

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
