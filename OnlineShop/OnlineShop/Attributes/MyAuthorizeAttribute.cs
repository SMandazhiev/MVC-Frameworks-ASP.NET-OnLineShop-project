using System.Linq;
using System.Web.Mvc;

namespace OnlineShop.Web.Attributes
{
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var roles = Roles.Split(',');
            
            if (filterContext.HttpContext.Request.IsAuthenticated &&
                !roles.Any(s => filterContext.HttpContext.User.IsInRole(s)))
            {
                filterContext.Result = new ViewResult()
                {
                    ViewName = "~/Views/Shared/Unauthorized.cshtml"
                };
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
            
        }
    }
}