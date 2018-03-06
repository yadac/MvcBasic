using System.Collections.Specialized;
using System.Globalization;
using System.Web.Mvc;

namespace MvcBasic.Extentions
{
    public class HttpCookieValueProviderFactory : ValueProviderFactory
    {
        public override IValueProvider GetValueProvider(ControllerContext controllerContext)
        {
            var list = new NameValueCollection();

            // クッキー情報をNaeValueCollectionに詰め替え
            var cookies = controllerContext.HttpContext.Request.Cookies;
            foreach (var key in cookies.AllKeys)
            {
                list.Add(key, cookies[key].Value);
            }

            // NameValueCollectionから値プロバイダーを生成
            return new NameValueCollectionValueProvider(list, CultureInfo.CurrentCulture);
        }
    }
}