using OnlineShop.Models.EntityModels;

namespace OnlineShopServices.Interfaces
{
    public interface IAccountService
    {
        void CreateClient(ApplicationUser user, decimal accountBalance);
    }
}