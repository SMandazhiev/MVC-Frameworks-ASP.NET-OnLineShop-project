using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Models.ViewModels.Products;
using OnlineShopServices;
using OnlineShopServices.Interfaces;

namespace OnlineShop.Web.Controllers
{
    [Authorize(Roles = "Client")]
    public class HomeController : Controller
    {
        private IHomeService service;

        public HomeController(IHomeService service)
        {
            this.service = service;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            IEnumerable<ProductVm> vms = this.service.GetAllProducts();
            return this.View(vms);
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            return this.View();
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            return this.View();
        }


    }
}