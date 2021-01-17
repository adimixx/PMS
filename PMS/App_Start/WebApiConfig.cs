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
               name: "DatabaseAPI",
               routeTemplate: "SystemAPI/Database/{action}/{id}",
               defaults: new { id = RouteParameter.Optional, controller = "DatabaseAPI" }
           );

            config.Routes.MapHttpRoute(
               name: "StudioAPI",
               routeTemplate: "SystemAPI/Studio/{action}/{id}",
               defaults: new { id = RouteParameter.Optional, controller = "StudioAPI" }
           );

            config.Routes.MapHttpRoute(
                name: "JobAPI",
                routeTemplate: "SystemAPI/Job/{action}/{id}",
                defaults: new { id = RouteParameter.Optional, controller = "JobAPI" }
            );

            config.Routes.MapHttpRoute(
                name: "PackageImageAPI",
                routeTemplate: "SystemAPI/PackageImage/{action}/{id}",
                defaults: new { id = RouteParameter.Optional, controller = "PackageImageAPI" }
            );

            config.Routes.MapHttpRoute(
                name: "ChatPackageAPI",
                routeTemplate: "SystemAPI/Package/{action}/{id}",
                defaults: new { id = RouteParameter.Optional, controller = "ChatPackageAPI" }
            );

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
