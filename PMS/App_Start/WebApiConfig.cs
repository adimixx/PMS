using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PMS
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "AccountAPI",
                routeTemplate: "SystemAPI/Account/{action}/{id}",
                defaults: new { id = RouteParameter.Optional, controller = "AccountAPI" }
            );

            config.Routes.MapHttpRoute(
                name: "StudioRolesAPI",
                routeTemplate: "SystemAPI/StudioRoles/{action}/{id}",
                defaults: new { id = RouteParameter.Optional, controller = "StudioRolesAPI" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // config to return json
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
