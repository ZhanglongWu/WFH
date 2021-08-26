namespace Wicresoft.WFH.Api
{
    using System.Web.Mvc;
    using System.Web.Http;
    using System.Web.Routing;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            RouteConfig.RegisterRoutes(RouteTable.Routes);

            UnityConfig.RegisterComponents();

            GlobalConfiguration.Configuration.DependencyResolver =
                new Unity.WebApi.UnityDependencyResolver(UnityConfig.RootContainer);
        }
    }
}
