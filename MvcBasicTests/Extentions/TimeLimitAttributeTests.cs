using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcBasic.Extentions;

namespace MvcBasicTests.Extentions
{
    [TestClass()]
    public class TimeLimitAttributeTests
    {

        [TestMethod()]
        public void OnAuthorizationSuccessTest()
        {
            var context = new AuthorizationContext();
            var attr = new TimeLimitAttribute("2014/01/01", "2014/12/31");
            attr.OnAuthorization(context);

            //Assert.AreEqual(1,1);
            Assert.IsInstanceOfType(context.Result, typeof(ContentResult));
            Assert.AreEqual(
                "このページは Wednesday, January 1, 2014 から Wednesday, December 31, 2014 までの期間のみ有効です"
                , ((ContentResult)context.Result).Content);
        }

        [TestMethod]
        public void OnAuthorizationFailTest()
        {
            var context = new AuthorizationContext();
            var attr = new TimeLimitAttribute("2018/01/01", "2018/12/31");
            attr.OnAuthorization(context);

            Assert.AreEqual(context.Result, null);
        }
    }
}