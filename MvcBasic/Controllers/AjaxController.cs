using MvcBasic.Models;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace MvcBasic.Controllers
{
    public class AjaxController : Controller
    {

        private readonly MvcBasicContext _db = new MvcBasicContext();

        // GET: Ajax
        public ActionResult Index()
        {
            return Content("not imple");
        }

        public ActionResult AjaxLink()
        {
            var list = EnumHelper.GetSelectList(typeof(CategoryEnum));
            return View(list);
        }

        public ActionResult AjaxSearch(CategoryEnum id)
        {
            if (Request.IsAjaxRequest())
            {
                var articles = _db.Articles.Where(a => a.Category == id).OrderBy(a => a.Published);
                return PartialView("_AjaxSearch", articles);
            }

            return View("AjaxLink");
        }
    }
}