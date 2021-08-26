namespace Wicresoft.WFH.Api
{
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using System.Net.Http.Formatting;
    using System.Web.Http.ExceptionHandling;

    using Newtonsoft.Json.Serialization;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

#if DEBUG
            var cors = new EnableCorsAttribute("*", "*", "PUT,GET,POST,DELETE,OPTIONS")
            {
                SupportsCredentials = true
            };
#else
            var cors = new EnableCorsAttribute(Configuration.CorsOrigin, "*", "PUT,GET,POST,DELETE,OPTIONS")
            {
                SupportsCredentials = true
            };
#endif
            config.EnableCors(cors);

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
