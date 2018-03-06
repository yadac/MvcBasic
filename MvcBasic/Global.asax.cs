using MvcBasic.Extentions;
using MvcBasic.Migrations;
using MvcBasic.Models;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

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
            // Database.SetInitializer<MvcBasicContext>(new MvcBasicInitializer());

            // if you dont need create initialize data, you set base class directly for create database/table
            // Database.SetInitializer<MvcBasicContext>(new DropCreateDatabaseAlways<MvcBasicContext>());

            // initialize by Configuration.cs
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MvcBasicContext, Configuration>());

            // 自作の値プロバイダーをアプリケーションに登録
            ValueProviderFactories.Factories.Add(new HttpCookieValueProviderFactory());
        }
    }
}
