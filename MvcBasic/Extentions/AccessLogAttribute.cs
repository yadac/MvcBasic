using MvcBasic.Models;
using System;
using System.Web.Mvc;

namespace MvcBasic.Extentions
{
    public class AccessLogAttribute : ActionFilterAttribute
    {
        private readonly MvcBasicContext _db = new MvcBasicContext();

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            if (filterContext == null) throw new ArgumentNullException($"filtercontext");

            var req = filterContext.HttpContext.Request;
            var log = new AccessLog()
            {
                Url = req.Url.AbsoluteUri,
                UserAgent = req.UserAgent,
                Accessed = DateTime.Now,
            };
            _db.AccessLogs.Add(log);
            _db.SaveChanges();
        }

    }
}