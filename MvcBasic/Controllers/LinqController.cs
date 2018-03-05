using MvcBasic.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MvcBasic.Controllers
{
    public class LinqController : Controller
    {
        // create context
        private MvcBasicContext _db = new MvcBasicContext();

        // GET: Linq
        public ActionResult Search(string keyword, bool? released)
        {
            // all data
            var articles = from a in _db.Articles select a;

            // if keyword exists
            if (!string.IsNullOrEmpty(keyword))
            {
                articles = articles.Where(a => a.Title.Contains(keyword));
            }

            if (released.HasValue && released.Value)
            {
                articles = articles.Where(a => a.Released);
            }

            return View(articles);
        }

        public ActionResult Select()
        {
            var articles = from a in _db.Articles
                           orderby a.Published descending
                           select new ArticleView
                           {
                               Title = a.Title.Substring(0, 10),
                               Viewcount = (int)Math.Ceiling(a.ViewCount / 1000.0),
                               Released = (a.Released ? "公開中" : "公開予定"),
                           };
            return View(articles);
        }
    }
}