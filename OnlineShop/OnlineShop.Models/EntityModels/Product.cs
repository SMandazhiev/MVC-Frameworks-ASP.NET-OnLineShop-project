using System.Collections.Generic;

namespace OnlineShop.Models.EntityModels
{
    public class Product
    {
        public Product()
        {
           this.Clients = new HashSet<Client>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public string Picture { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }
}