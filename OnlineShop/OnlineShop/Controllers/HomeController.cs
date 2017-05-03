using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Models.ViewModels.Products;
using OnlineShopServices;
using OnlineShopServices.Interfaces;

namespace OnlineShop.Web.Controllers
{
    // [MyAuthorize(Roles="Admin")]
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

        [Route("upload")]
        public ActionResult UploadFile()
        {
            return this.View();
        }

        [HttpPost]
        [Route("upload")]
        [ActionName("UploadFile")]
        public ActionResult Upload()
        {
            HttpPostedFileBase file = Request.Files[0];
            string fileName = Path.GetFileName(file.FileName);
            string path = Path.Combine(Server.MapPath("~/UploadedFiles"), fileName);
            file.SaveAs(path);
            return RedirectToAction("Index");
        }
    }
}