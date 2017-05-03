using AutoMapper;
using OnlineShop.Models.EntityModels;
using OnlineShop.Models.ViewModels.Products;
using OnlineShopServices.Interfaces;

namespace OnlineShopServices
{
    public class ProductService : Service, IProductService
    {
        public DetailsProductVm GetDetails(int id)
        {
            Product product = this.Context.Products.Find(id);
            if (product==null)
            {
                return null;
            }

            DetailsProductVm vm = Mapper.Map<Product, DetailsProductVm>(product);
            return vm;
        }
    }
}