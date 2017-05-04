using System.IO;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Models.ViewModels.Admin;
using OnlineShopServices;
using OnlineShopServices.Interfaces;

namespace OnlineShop.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [RouteArea("admin")]
    public class AdminController : Controller
    {
        private IAdminService service;

        public AdminController(IAdminService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route]
        public ActionResult Index()
        {
            AdminPageVm vm = this.service.GetAdminPage();
          return  this.View(vm);
        }

        [HttpGet]
        [Route("product/add")]
        public ActionResult AddProduct()
        {
            
            return this.View();
        }

        [HttpGet]
        [Route("product/{id}/edit")]
        public ActionResult EditProduct(int id)
        {
            return this.View();
        }

        [HttpGet]
        [Route("users/{id}/edit")]
        public ActionResult EditUser(int id)
        {
            return this.View();
        }

        [Route("upload")]
        [Authorize(Roles = "Admin")]
        public ActionResult UploadFile()
        {
            return this.View();
        }

        [HttpPost]
        [Route("upload")]
        [ActionName("UploadFile")]
        [Authorize(Roles = "Admin")]
        public ActionResult Upload()
        {
            HttpPostedFileBase file = Request.Files[0];
            string fileName = Path.GetFileName(file.FileName);
            string path = Path.Combine(Server.MapPath("~/Content/img"), fileName);
            file.SaveAs(path);
            return RedirectToAction("Index");
        }

    }
}