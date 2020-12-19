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
                name: "Package",
                url: "{permalink}/Package/{action}/{id}",
                defaults: new { controller = "Package", action = "PackageHome", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "JobStatus",
                url: "JobStatus/{action}/{id}",
                defaults: new { controller = "Job", action = "JobStatusMain", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "JobAdmin",
                url: "{permalink}/JobAdmin/{action}/{id}",
                defaults: new { controller = "Job", action = "JobHomeAdmin", id = UrlParameter.Optional }
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
