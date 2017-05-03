using OnlineShop.Models.ViewModels.Products;

namespace OnlineShopServices.Interfaces
{
    public interface IProductService
    {
        DetailsProductVm GetDetails(int id);
    }
}