using System.Collections.Generic;
using AutoMapper;
using OnlineShop.Models.EntityModels;
using OnlineShop.Models.ViewModels.Products;
using OnlineShopServices.Interfaces;

namespace OnlineShopServices
{
    public class HomeService : Service, IHomeService
    {
        public IEnumerable<ProductVm> GetAllProducts()
        {
            IEnumerable<Product> products = Context.Products;
            IEnumerable<ProductVm> vms = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductVm>>(products);
            return vms;
        }
    }
}