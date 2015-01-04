using System.Web.Http;
using System.Net.Http.Headers;

namespace Delta.AppHarbor
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // From http://stackoverflow.com/questions/9847564/how-do-i-get-asp-net-web-api-to-return-json-instead-of-xml-using-chrome
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            
            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(name: "SitiApi",
                routeTemplate: "siti/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}
