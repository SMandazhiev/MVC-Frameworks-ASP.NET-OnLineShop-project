using System.Collections.Generic;
using OnlineShop.Models.EntityModels;

namespace OnlineShop.Models.ViewModels.Users
{
    public class ProfileVm
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public decimal AccountBalance { get; set; }
        public IEnumerable<UsersProductsVm> EnrolledProducts { get; set; }
        public ICollection<Purchase> Purchases { get; set; }
        public ICollection<Purchase> PurchasesCount { get; set; }
        

        public decimal TotalPriceOfProducts { get; set; }

    }
}