using MvcBasic.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBasic.Controllers
{
    public class BindController : Controller
    {
        private MvcBasicContext _db = new MvcBasicContext();

        // GET: Bind
        public ActionResult CreateList()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateList(IList<Member> list)
        {
            try
            {
                // リストから順にMemberプロパティを取り出す
                foreach (var member in list)
                {
                    // 空になったら終了
                    if (string.IsNullOrEmpty(member.Name)) break;
                    _db.Members.Add(member);
                }

                _db.SaveChanges();
                // 他のコントローラのアクションを呼び出す
                return RedirectToAction("Index", "Members");
            }
            catch (Exception e)
            {
                // 再度入力画面へ
                return View();
            }
        }

        public ActionResult Index()
        {
            throw new NotImplementedException();
        }

        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase data)
        {
            if (data != null)
            {
                var f = data.FileName;

                // 拡張子チェック
                var permit = new string[] { ".jpg", ".png", ".gif" };
                if (!permit.Contains(Path.GetExtension(f)))
                {
                    ViewBag.Message = "jpg, png, gif 以外のファイルはアップロードできません";
                    return View();
                }

                // アップロードファイル保存
                data.SaveAs(Path.Combine(Server.MapPath("~/App_Data/Photos"), Path.GetFileName(f)));
                ViewBag.Message = f + " をアップロードしました。";

                // データベースにも保存
                // バイト配列に読み込んでimageオブジェクト生成
                byte[] bytes = new byte[data.ContentLength];
                data.InputStream.Read(bytes, 0, data.ContentLength);
                var img = new MvcBasic.Models.Image()
                {
                    Name = Path.GetFileName(f),
                    Ctype = data.ContentType,
                    Data = bytes
                };
                _db.Images.Add(img);
                _db.SaveChanges();

            }
            else
            {
                ViewBag.Message = "ファイルを指定してください。";
            }

            return View();
        }

    }
}