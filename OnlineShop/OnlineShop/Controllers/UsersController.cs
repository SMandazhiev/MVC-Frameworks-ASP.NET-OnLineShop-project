using System.Web.Mvc;
using OnlineShop.Models.BindingModels.Users;
using OnlineShop.Models.EntityModels;
using OnlineShop.Models.ViewModels.Users;
using OnlineShopServices;
using OnlineShopServices.Interfaces;

namespace OnlineShop.Web.Controllers
{
    [Authorize(Roles = "Client")]
    [RoutePrefix("users")]
    public class UsersController : Controller
    {
        private IUsersService service;

        public UsersController(IUsersService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("enroll")]
        public ActionResult Enroll(int productId)
        {
            string userName = this.User.Identity.Name;
            Client client = this.service.GetCurrentClient(userName);
            service.EnrollClientInProduct(productId, client);
            return this.RedirectToAction("Profile");
        }

        [Route("profile")]
        public ActionResult Profile()
        {
            string userName = this.User.Identity.Name;
            ProfileVm vm =  this.service.GetProfiveVm(userName);
            return this.View(vm);
        }

        [HttpGet]
        [Route("edit")]
        public ActionResult Edit()
        {
            string userName = this.User.Identity.Name;
            EditUserVm vm = this.service.GetEditVm(userName);

            return this.View(vm);
        }

        [HttpPost]
        [Route("edit")]
        public ActionResult Edit(EditUserBm bind)
        {
            if (this.ModelState.IsValid)
            {
                string currentUserName = this.User.Identity.Name;
                this.service.EditUser(bind, currentUserName);
                return this.RedirectToAction("Profile");
            }

            string userName = this.User.Identity.Name;
            EditUserVm vm = this.service.GetEditVm(userName);
            return this.View(vm);
        }

    }
}