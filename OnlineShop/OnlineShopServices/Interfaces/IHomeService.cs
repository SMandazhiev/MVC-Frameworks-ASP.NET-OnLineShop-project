using System.Collections.Generic;
using OnlineShop.Models.ViewModels.Products;

namespace OnlineShopServices.Interfaces
{
    public interface IHomeService
    {
        IEnumerable<ProductVm> GetAllProducts();
    }
}