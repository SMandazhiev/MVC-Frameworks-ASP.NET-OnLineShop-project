using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using OnlineShop.Models.BindingModels.Users;
using OnlineShop.Models.EntityModels;
using OnlineShop.Models.ViewModels.Products;
using OnlineShop.Models.ViewModels.Users;
using OnlineShopServices.Interfaces;

namespace OnlineShopServices
{
    public class UsersService : Service, IUsersService
    {
        public Client GetCurrentClient(string userName)
        {
            var user = Context.Users.FirstOrDefault(applicationUser => applicationUser.UserName == userName);
            Client client = Context.Clients.FirstOrDefault(client1 => client1.User.Id == user.Id);
            return client;
        }

        public void EnrollClientInProduct(int productId, Client client)
        {
            Product wantedProduct = this.Context.Products.Find(productId);
            client.Products.Add(wantedProduct);
            if (wantedProduct!=null)
            {
                wantedProduct.Amount--;
            }
            
            int purchaseNumber = 1;
            foreach (var purchase in client.Purchases)
            {
                if (purchase.Product.Id == wantedProduct.Id)
                {
                    purchaseNumber = purchase.PurchaseNumber + 1;
                }
            }
            client.Purchases.Add(new Purchase() { Product = wantedProduct, PurchaseNumber = purchaseNumber });
            this.Context.SaveChanges();
        }

        public ProfileVm GetProfiveVm(string userName)
        {
            ApplicationUser currentUser = Context.Users.FirstOrDefault(user => user.UserName == userName);
            ProfileVm vm = Mapper.Map<ApplicationUser, ProfileVm>(currentUser);

            Client currentClient = Context.Clients.FirstOrDefault(clien => clien.User.Id == currentUser.Id);
            vm.EnrolledProducts = Mapper.Map<IEnumerable<Product>, IEnumerable<UsersProductsVm>>(currentClient.Products);

            Client currentClientForMappingAccountBalance = Context.Clients.FirstOrDefault(user1 => user1.User.UserName == userName);
            vm.AccountBalance = Mapper.Map<decimal, decimal>(currentClientForMappingAccountBalance.AccountBalance);

            Client currentClientForPurchises = Context.Clients.FirstOrDefault(user2 => user2.User.UserName == userName);
            vm.Purchases = Mapper.Map<ICollection<Purchase>, ICollection<Purchase>>(currentClientForPurchises.Purchases);
            //////////

            // foreach (var productPrice in vm.EnrolledProducts)
            // {
            //     totalProductsPrice += productPrice.Price;
            // }
            // vm.TotalPriceOfProducts = totalProductsPrice;
            //////////
            vm.PurchasesCount = new List<Purchase>();

            Dictionary<int, int> purchasesById = new Dictionary<int, int>();
            Dictionary<Product, int> purchases = new Dictionary<Product, int>();

            foreach (var purchase in vm.Purchases)
            {
                if (purchasesById.ContainsKey(purchase.Product.Id))
                {
                    purchasesById[purchase.Product.Id]++;
                    purchases[purchase.Product]++;
                }
                else
                {
                    purchasesById.Add(purchase.Product.Id, 1);
                    purchases.Add(purchase.Product, 1);
                }
            }

            foreach (var purchase in purchases)
            {
                vm.PurchasesCount.Add(new Purchase()
                {
                    Product = purchase.Key,
                    PurchaseNumber = purchase.Value,
                    ProductTypeCosts = purchase.Key.Price * purchase.Value
                });

            }

            decimal totalProductsPrice = 0m;
            foreach (var purchase in purchases)
            {
                totalProductsPrice += (purchase.Key.Price * purchase.Value);
            }
            vm.TotalPriceOfProducts = totalProductsPrice;
            return vm;
        }

        public EditUserVm GetEditVm(string userName)
        {
            ApplicationUser user = this.Context.Users.FirstOrDefault(applicationUser => applicationUser.UserName == userName);
            EditUserVm vm = Mapper.Map<ApplicationUser, EditUserVm>(user);
            return vm;
        }

        public void EditUser(EditUserBm bind, string currentUserName)
        {
            ApplicationUser user =
                this.Context.Users.FirstOrDefault(applicationUser => applicationUser.UserName == currentUserName);
            user.Name = bind.Name;
            user.Email = bind.Email;
            this.Context.SaveChanges();
        }
    }
}
