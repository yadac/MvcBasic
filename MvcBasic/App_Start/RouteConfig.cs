using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcBasic
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // 特殊ルートを先に記述
            routes.MapRoute(
                name: "Blog",
                url: "Blog/{year}",
                defaults: new { controller = "Home", action = "Index", year = UrlParameter.Optional, }
            );

            // RouteTest
            routes.MapRoute(
                name: "Route",
                url: "Route/Test/{year}/{month}/{day}",
                defaults: new
                {
                    controller = "Route",
                    action = "Test",
                    year = DateTime.Now.Year,
                    month = DateTime.Now.Month,
                    day = DateTime.Now.Day
                }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
