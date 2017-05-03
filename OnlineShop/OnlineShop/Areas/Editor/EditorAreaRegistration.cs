using System.Web.Mvc;

namespace OnlineShop.Web.Areas.Editor
{
    public class EditorAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Editor";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.Routes.MapMvcAttributeRoutes();
       //     context.MapRoute(
       //         "Editor_default",
       //         "{controller}/{action}/{id}",
       //         new { action = "Index", id = UrlParameter.Optional }
       //     );
        }
    }
}