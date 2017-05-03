using System.Collections.Generic;

namespace OnlineShop.Models.EntityModels
{
    public class Client
    {
        public Client()
        {
          this.Products = new HashSet<Product>();
          this.Purchases = new List<Purchase>();
        }
        public int Id { get; set; }
        public decimal AccountBalance { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual  ICollection<Purchase> Purchases  { get; set; }
    }
}