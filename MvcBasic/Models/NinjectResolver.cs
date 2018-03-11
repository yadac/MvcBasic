using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;

namespace MvcBasic.Models
{
    public class NinjectResolver : IDependencyResolver
    {
        private IKernel _kernel;

        // Ninjectのカーネルを準備
        public NinjectResolver(IKernel k)
        {
            _kernel = k;
        }

        // 単一のサービスを解決
        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        // 複数のサービスを解決
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
    }
}