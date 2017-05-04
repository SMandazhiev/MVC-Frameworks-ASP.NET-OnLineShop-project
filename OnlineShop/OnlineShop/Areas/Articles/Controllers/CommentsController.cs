using System.Collections.Generic;
using System.Web.Mvc;
using OnlineShop.Models.BindingModels.Editor;
using OnlineShop.Models.ViewModels.Comments;
using OnlineShopServices.Interfaces;

namespace OnlineShop.Web.Areas.Articles.Controllers
{
    [RouteArea("Articles")]
   // [RoutePrefix("comments")]
    [Authorize(Roles = "Client")]
    public class CommentsController : Controller
    {
        private ICommentService service;

        public CommentsController(ICommentService service)
        {
            this.service = service;
        }

        [Route("AllArticles")]
        public ActionResult AllArticles()
        {
            IEnumerable<CommentVm> vms = this.service.GetAllArticles();
            return this.View(vms);
        }

        //  [Authorize(Roles = "Client")]
        //  [ChildActionOnly]
        //  public ActionResult CreationVisualize()
        //  {
        //      return PartialView("_AddButton");
        //  }

        [HttpGet]
        [Authorize(Roles = "Client")]
        [Route("add")]
        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = "Client")]
        [Route("add")]
        public ActionResult Add(AddCommentBm bind)
        {
            if (this.ModelState.IsValid)
            {
                string username = this.User.Identity.Name;
                this.service.AddNewArticle(bind, username);
                return this.RedirectToAction("AllArticles");
            }
            else
            {
                return this.View();
            }
        }
    }
}