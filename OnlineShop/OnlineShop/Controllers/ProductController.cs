using System.Web.Mvc;
using OnlineShop.Models.ViewModels.Products;
using OnlineShopServices;
using OnlineShopServices.Interfaces;

namespace OnlineShop.Web.Controllers
{
    [Authorize(Roles = "Client,Editor,Admin")]
    [RoutePrefix("product")]
    public class ProductController : Controller
    {
        private IProductService service;
        
        public ProductController(IProductService service)
        {
            this.service = service;
        }

        [HttpGet, Route("details/{id}")]
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            DetailsProductVm vm = this.service.GetDetails(id);
            if (vm == null)
            {
                return this.HttpNotFound();
            }

            return this.View(vm);
        }

        
    }
}