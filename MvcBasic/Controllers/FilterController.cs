using MvcBasic.Extentions;
using System;
using System.Web.Mvc;

namespace MvcBasic.Controllers
{
    [Authorize]
    public class FilterController : Controller
    {
        [AllowAnonymous]
        [OutputCache(CacheProfile = "MyPolicy")]
        // GET: Filter
        public ActionResult Index()
        {
            return Content("not implemented");
        }

        [AllowAnonymous]
        public ActionResult Exception()
        {
            throw new Exception("Fatal Error");
        }

        [AllowAnonymous]
        [HandleError(View = "ErrorSpare")]  // 個別にエラーページを指定
        public ActionResult ExceptionSpare()
        {
            throw new Exception("Fatal Error Spare");
        }

        [OverrideAuthorization]
        [TimeLimit("2018-01-01", "2018-03-31")]
        public ActionResult Limit()
        {
            return Content("有効期間中です");
        }

        [OverrideAuthorization]
        [LoggingError]
        public ActionResult Log()
        {
            throw new Exception("Error Raised!!");
        }

    }
}