using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineShop.Models.EntityModels;

namespace OnlineShop.Data
{
    public class OnlineShopContext : IdentityDbContext<ApplicationUser>
    {
       public OnlineShopContext()
            : base("name=OnlineShop", throwIfV1Schema: false)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public static OnlineShopContext Create()
        {
            return new OnlineShopContext();
        }
      }

}