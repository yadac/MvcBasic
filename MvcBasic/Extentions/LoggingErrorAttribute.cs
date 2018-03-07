using MvcBasic.Models;
using System;
using System.Web.Mvc;

namespace MvcBasic.Extentions
{
    public class LoggingErrorAttribute : FilterAttribute, IExceptionFilter
    {
        private readonly MvcBasicContext _db = new MvcBasicContext();

        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext == null) throw new ArgumentNullException($"filterContext");

            var route = filterContext.RouteData;
            var exp = filterContext.Exception;

            var err = new ErrorLog()
            {
                Controller = route.Values["controller"].ToString(),
                Action = route.Values["action"].ToString(),
                Message = exp.Message,
                Stacktrace = exp.StackTrace,
                Updated = DateTime.Now,
            };
            _db.ErrorLogs.Add(err);
            _db.SaveChanges();
        }
    }
}