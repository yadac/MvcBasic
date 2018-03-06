using MvcBasic.Models;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Mvc;
using System.Xml.Linq;

namespace MvcBasic.Controllers
{
    public class ResultController : Controller
    {
        private MvcBasicContext _db = new MvcBasicContext();

        // GET: Result
        public ActionResult Index()
        {
            return Content("not implemented");
        }

        public ActionResult Empty()
        {
            // 空ページ返却
            return new EmptyResult();
        }

        public ActionResult Tsv()
        {
            var members = _db.Members.ToList();
            var str = new StringBuilder();
            members.ForEach(m => str.Append($"{m.Id}\t{m.Name}\t{m.Email}\r\n"));
            return Content(str.ToString(), "text/tab-separated-values", Encoding.UTF8);

        }

        public ActionResult Rss()
        {
            // 出版日の降順に先頭15件取得
            var contents = (from c in _db.Articles orderby c.Published descending select c).Take(15).ToList();

            // フィードの生成
            var rss = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement(
                    "rss",
                    new XAttribute("version", "2.0"),
                    new XElement("channel", new XElement("url", "http://www.wings.msn.to/image/wings.jpg"),
                        new XElement("link", "http://www.wings.msn.to/"),
                        new XElement("title", "サーバサイド技術の学び舎")),
                    from c in contents
                    select new XElement("item",
                        new XElement("title", c.Title),
                        new XElement("link", c.Url),
                        new XElement("description", c.Description),
                        new XElement("category", c.Category),
                        new XElement("viewcount", c.ViewCount),
                        new XElement("pubdate", c.Published.ToUniversalTime().ToString("R")))));
            return Content(rss.ToString(), "application/rss+xml");

        }

        public ActionResult Download(int? id)
        {
            // id 未指定
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var pic = Server.MapPath($"~/App_Data/Photos/{id}.jpg");
            if (System.IO.File.Exists(pic))
            {
                return File(pic, "image/jpg", "download.jpg");
            }
            else
            {
                return HttpNotFound("file does not exists.");
            }
        }

        public ActionResult Image(int id)
        {
            var img = _db.Images.Find(1);
            if (img == null) return HttpNotFound();
            return File(img.Data, img.Ctype, img.Name);
        }
    }
}