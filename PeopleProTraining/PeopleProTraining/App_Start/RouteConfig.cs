using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PeopleProTraining
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Default route
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            // Employees route
            routes.MapRoute(
                name: "Employees",
                url: "{controller}/{action}/{name}/{id}"
            );

            // Departments route
            routes.MapRoute(
                name: "Departments",
                url: "{controller}/{action}/{name}/{id}"
            );

            // Buildings route
            routes.MapRoute(
                name: "Buildings",
                url: "{controller}/{action}/{name}/{id}"
            );
        }
    }
}
