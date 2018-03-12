using System.Web.Mvc;

namespace MvcBasic.Helpers
{
    public static class I18Helper
    {

        public static string GlobalResource(this HtmlHelper helper, string type, string key, params object[] args)
        {
            // type = "MyRes", key = "Today", args = DateTime
            var context = helper.ViewContext.HttpContext;
            return string.Format((string)context.GetGlobalResourceObject(type, key), args);
        }

        public static string LocalResrouce(this HtmlHelper helper, string key, params object[] args)
        {
            var context = helper.ViewContext.HttpContext;
            var view = helper.ViewContext.View as RazorView;
            return string.Format((string)context.GetLocalResourceObject(view.ViewPath, key), args);
        }
    }
}