using System.Collections.Generic;
using AutoMapper;
using OnlineShop.Models.EntityModels;
using OnlineShop.Models.ViewModels.Admin;
using OnlineShop.Models.ViewModels.Products;
using OnlineShopServices.Interfaces;

namespace OnlineShopServices
{
    public class AdminService : Service, IAdminService
    {
        public AdminPageVm GetAdminPage()
        {
            AdminPageVm page = new AdminPageVm();
            IEnumerable<Product> products = this.Context.Products;
            IEnumerable<Client> clients = this.Context.Clients;

            IEnumerable<ProductVm> productVms = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductVm>>(products);
            IEnumerable<AdminPageUserVm> userVms = Mapper.Map<IEnumerable<Client>, IEnumerable<AdminPageUserVm>>(clients);

            page.Users = userVms;
            page.Products = productVms;

            return page;


        }
    }
}