using MvcBasic.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MvcBasic.Controllers
{
    public class AttributeController : Controller
    {

        private MvcBasicContext _db = new MvcBasicContext();

        // GET: Attribute
        public ActionResult Index()
        {
            return Content("not implemented");
        }

        [Route("Attr/Articles/{category?}")]
        public ActionResult ShowByCategory(string category)
        {
            var list = from a in _db.Articles select a;
            if (category != null)
            {
                var c = (CategoryEnum)Enum.Parse(typeof(CategoryEnum), category);
                list = list.Where(a => a.Category == c);
            }

            TempData["cat"] = category;
            return View(list);

        }
    }
}