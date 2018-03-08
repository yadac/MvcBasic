﻿using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcBasic
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // 属性ルートの有効化
            routes.MapMvcAttributeRoutes();

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
                    day = DateTime.Now.Day,
                },
                constraints: new
                {
                    year = @"\d{4}",
                    month = @"\d{1,2}",
                    day = @"\d{1,2}",
                    verbs = new HttpMethodConstraint("GET"),
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
