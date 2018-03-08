using System;
using System.Reflection;
using System.Web.Mvc;

namespace MvcBasic.Extentions
{
    public class ReferrerAttribute : ActionMethodSelectorAttribute
    {

        public bool CanNull { get; private set; }

        public ReferrerAttribute(bool canNull)
        {
            CanNull = canNull;
        }

        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            var req = controllerContext.HttpContext.Request;
            var referrer = req.UrlReferrer;
            if (referrer == null) return CanNull;
            var refHost = referrer.Host;
            var curHost = req.Url.Host;

            return refHost.Equals(curHost, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}