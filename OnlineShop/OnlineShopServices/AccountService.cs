using OnlineShop.Models.EntityModels;
using OnlineShopServices.Interfaces;

namespace OnlineShopServices
{
    public class AccountService : Service, IAccountService
    {
        public void CreateClient(ApplicationUser user, decimal accountBalance)
        {
            Client client = new Client();
            ApplicationUser currentUser = this.Context.Users.Find(user.Id);
            client.User = currentUser;
            client.AccountBalance = accountBalance;
            this.Context.Clients.Add(client);
            this.Context.SaveChanges();
        }
    }
}