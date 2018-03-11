using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBasic.Helpers
{
    public static class MyHelper
    {
        public static IHtmlString Image(this HtmlHelper helper, string src, string alt)
        {
            return MvcHtmlString.Create(
                string.Format(
                    $"<img src='{HttpUtility.HtmlAttributeEncode(UrlHelper.GenerateContentUrl(src, helper.ViewContext.HttpContext))}' " +
                    $"alt='{HttpUtility.HtmlAttributeEncode(alt)}' />"));
        }
    }
}