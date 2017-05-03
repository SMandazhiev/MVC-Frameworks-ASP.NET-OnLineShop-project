using System.Collections.Generic;
using OnlineShop.Models.ViewModels.Products;

namespace OnlineShop.Models.ViewModels.Admin
{
    public class AdminPageVm
    {
        public IEnumerable<ProductVm>  Products { get; set; }
        public IEnumerable<AdminPageUserVm> Users { get; set; } 
    }
}