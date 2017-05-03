using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using OnlineShop.Models.BindingModels.Editor;
using OnlineShop.Models.EntityModels;
using OnlineShop.Models.ViewModels.Admin;
using OnlineShop.Models.ViewModels.Comments;
using OnlineShop.Models.ViewModels.Products;
using OnlineShop.Models.ViewModels.Users;
using OnlineShopServices;

namespace OnlineShop.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ConfigureMappings();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void ConfigureMappings()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<Product, DetailsProductVm>();
                expression.CreateMap<Product, ProductVm>();
                expression.CreateMap<ApplicationUser, ProfileVm>();
                expression.CreateMap<Product, UsersProductsVm>();
                expression.CreateMap<ApplicationUser, EditUserVm>();
                expression.CreateMap<Comment, CommentVm>();
                expression.CreateMap<ApplicationUser, CommentAutorVm>();
                expression.CreateMap<AddCommentBm, Comment>();
                expression.CreateMap<Client, AdminPageUserVm>().ForMember(vm=>vm.Name, 
                    configurationExpression=>
                    configurationExpression.MapFrom(client=>client.User.Name));

            });
        }
    }
}
