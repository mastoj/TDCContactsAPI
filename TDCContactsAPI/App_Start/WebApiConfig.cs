using System.Web.Http;
using TDCContactsAPI.Filters;
using TDCContactsAPI.Formatters;
using TDCContactsAPI.Handlers;

namespace TDCContactsAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.MessageHandlers.Add(new CorsHandler());
            config.Formatters.Add(new JpgMediaFormatter());
            config.Filters.Add(new ValidationActionFilter());
        }
    }
}
