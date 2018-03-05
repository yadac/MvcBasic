using MvcBasic.Models;
using System;
using System.Web.Mvc;

namespace MvcBasic.Controllers
{
    public class OtherController : Controller
    {
        private MvcBasicContext db = new MvcBasicContext();


        // GET: Other
        public ActionResult Insert()
        {
            // get target article
            var article = db.Articles.Find(2);

            // add comment
            db.Comments.Add(new Comment()
            {
                Article = article,
                Name = "Koizumi",
                Body = "感動した！",
                Updated = DateTime.Parse("2014-6-20")
            });
            db.SaveChanges();

            return Content("Added Comment");
        }

        public ActionResult Update()
        {
            // コメント1を記事4に付与
            var article = db.Articles.Find(4);
            var comment = db.Comments.Find(1);
            article.Comments.Add(comment);
            db.SaveChanges();

            return Content("Updated Article!");
        }

        public ActionResult Delete()
        {
            var article = db.Articles.Find(4);
            db.Articles.Remove(article);
            db.SaveChanges();
            return Content("Deleted Article!");
        }
    }
}