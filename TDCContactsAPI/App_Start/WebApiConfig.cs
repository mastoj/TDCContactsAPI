using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TDCContactsAPI.Controllers;
using TDCContactsAPI.Filters;
using TDCContactsAPI.Handlers;
using TDCContactsAPI.IoC;

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

            config.Formatters.Add(new JpgMediaFormatter());
            config.MessageHandlers.Add(new CorsHandler());
            config.Filters.Add(new ValidationActionFilter());
            config.DependencyResolver = new MyResolver();
        }
    }
}
