using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using System.Web.Routing;

namespace PMS
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Database",
                url: "Database/{action}/{id}",
               defaults: new { controller = "Database", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "Studio createchat",
               url: "{permalink}/createchat",
               defaults: new { controller = "Chat", action = "CreateChat", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "ChatStudio",
                url: "{permalink}/Chat",
               defaults: new { controller = "Chat", action = "ChatStudio", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "Chat",
                url: "Chat",
                defaults: new { controller = "Chat", action = "ChatUser", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Account",
                url: "Account/{action}/{id}",
                defaults: new { controller = "Account", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Studio",
                url: "Studio/{action}/{id}",
                defaults: new { controller = "Studio", action = "Manage", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Payment",
                url: "Payment/{action}/{id}",
                defaults: new { controller = "Payment", action = "CheckoutIndex", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Package",
                url: "{permalink}/Package/{action}/{id}",
                defaults: new { controller = "Package", action = "PackageHome", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Job",
                url: "{permalink}/Job/{action}/{id}",
                defaults: new { controller = "Job", action = "JobHome", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "JobCustomer",
                url: "JobC/{action}/{id}",
                defaults: new { controller = "Job", action = "JobCustomer", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "JobStatus",
                url: "JobStatus/{action}/{id}",
                defaults: new { controller = "Job", action = "JobStatusMain", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Home",
                url: "Home/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Studio Permalink",
                url: "{permalink}/{action}/{id}",
                defaults: new { controller = "StudioPermalink", action = "Index", id = UrlParameter.Optional }
            );

            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
