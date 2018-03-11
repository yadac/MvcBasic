using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MvcBasic.Models;
using Ninject;

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

            // 標準的なカーネルに紐づけ情報を登録
            IKernel kernel = new StandardKernel();
            kernel.Bind<IMemberRepository>().To<MemberRepository>();

            // 依存性リゾルバーを登録
            DependencyResolver.SetResolver(new NinjectResolver(kernel));

        }
    }
}
