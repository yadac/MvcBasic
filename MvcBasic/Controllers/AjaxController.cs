using MvcBasic.Extentions;
using MvcBasic.Models;
using System;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Xml.Linq;

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

        public ActionResult GourmetSearch()
        {
            return View();
        }

        [LoggingError]
        public ActionResult GourmetResult(string keyword)
        {
            if (Request.IsAjaxRequest())
            {
                // Webサービスのリクエスト情報
                // var keyid = "aec5fcce21332cae877dd6fadd973300"; // todo 公開しない方法に変更
                var keyid = ConfigurationManager.AppSettings["gnaviApiKey"];
                var prefid = "PREF13";
                var target = "https://api.gnavi.co.jp/RestSearchAPI/20150630";

                // Webサービスにアクセス
                var doc = XElement.Load($"{target}/?keyid={keyid}&name={Url.Encode(keyword)}&pref={prefid}&offset_page={1}");

                // ヒットした件数を取得
                ViewBag.Count = Int32.Parse(doc.Element("total_hit_count").Value);

                // 検索結果をレストラン情報に変換して画面に渡す
                return PartialView("_GourmetResult", from r in doc.Elements("rest")
                                                     select new Restaurant()
                                                     {
                                                         Id = r.Element("id").Value,
                                                         Name = r.Element("name").Value,
                                                         Url = r.Element("url").Value,
                                                         Image = r.Element("image_url").Element("qrcode").Value,
                                                         Pr = r.Element("pr").Element("pr_long").Value,
                                                     });
            }

            return View("GourmetSearch");
        }
    }
}