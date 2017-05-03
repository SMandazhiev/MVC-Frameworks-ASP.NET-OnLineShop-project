using OnlineShop.Data;

namespace OnlineShopServices
{
    public abstract class Service
    {
        public Service()
        {
            Context = new OnlineShopContext();
        }

        protected OnlineShopContext Context { get; }
    }
}