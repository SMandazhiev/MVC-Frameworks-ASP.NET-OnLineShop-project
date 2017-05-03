using OnlineShop.Models.BindingModels.Users;
using OnlineShop.Models.EntityModels;
using OnlineShop.Models.ViewModels.Users;

namespace OnlineShopServices.Interfaces
{
    public interface IUsersService
    {
        Client GetCurrentClient(string userName);
        void EnrollClientInProduct(int productId, Client client);
        ProfileVm GetProfiveVm(string userName);
        EditUserVm GetEditVm(string userName);
        void EditUser(EditUserBm bind, string currentUserName);
    }
}