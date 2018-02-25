using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MvcBasic.Models;

namespace MvcBasic
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // call initializer
            Database.SetInitializer<MvcBasicContext>(new MvcBasicInitializer());

            // if you dont need create initialize data, you set base class directly for create database/table
            // Database.SetInitializer<MvcBasicContext>(new DropCreateDatabaseAlways<MvcBasicContext>());

        }
    }
}
