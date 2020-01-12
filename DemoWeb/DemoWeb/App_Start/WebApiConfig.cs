using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DemoWeb
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "FlightsApi",
                routeTemplate: "api/flights/{id}",
                defaults: new { controller = "FlightsApi", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "WatchListEntriesApi",
                routeTemplate: "api/watchlist/{id}",
                defaults: new { controller = "WatchListEntriesApi", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            
            // Send JSON instead of XML
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings
                .Add(new System.Net.Http.Formatting.RequestHeaderMapping("Accept",
                "text/html",
                StringComparison.InvariantCultureIgnoreCase,
                true,
                "application/json"));
        }
    }
}
