using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Quotation",
                routeTemplate: "virtualmind/Cotizacion/{currency}",
                defaults: new { controller = "Quotation", currency = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "Users",
                routeTemplate: "virtualmind/Usuarios/{id}",
                defaults: new { controller = "Users", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "virtualmind/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
