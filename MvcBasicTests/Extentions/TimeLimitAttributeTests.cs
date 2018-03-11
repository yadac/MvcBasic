using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcBasic.Extentions;

namespace MvcBasicTests.Extentions
{
    [TestClass()]
    public class TimeLimitAttributeTests
    {

        [TestMethod()]
        public void OnAuthorizationTest()
        {
            var context = new AuthorizationContext();
            var attr = new TimeLimitAttribute("2014/12/01", "2014/12/31");
            attr.OnAuthorization(context);

            Assert.IsInstanceOfType(context.Result, typeof(ContentResult));
            Assert.AreEqual("このページは 2014/12/01 から 2014/12/31 までの期間のみ有効です", ((ContentResult)context.Result).Content);
        }
    }
}