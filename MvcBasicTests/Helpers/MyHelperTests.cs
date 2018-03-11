using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcBasic.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;

namespace MvcBasic.Helpers.Tests
{
    [TestClass()]
    public class MyHelperTests
    {
        [TestMethod()]
        public void ImageTest()
        {
            // Arrange
            var context = new Mock<HttpContextBase>();
            var ctrl = new Mock<ControllerBase>();
            var view = new Mock<IView>();

            // controller
            var ctrlContext = new ControllerContext(
                context.Object
                , new RouteData()
                , ctrl.Object);

            // view
            var viewContext = new ViewContext(
                ctrlContext
                , view.Object
                , new ViewDataDictionary()
                , new TempDataDictionary()
                , new StringWriter());

            var container = new Mock<IViewDataContainer>();
            var html = new HtmlHelper(viewContext, container.Object);

            var result = html.Image("sample.jpg", "test");
            Assert.AreEqual($"<img src ='sample.jpg' alt='test' />", result.ToString());

        }
    }
}