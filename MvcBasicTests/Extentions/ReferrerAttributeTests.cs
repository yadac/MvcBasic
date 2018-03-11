using System;
using System.Reflection;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvcBasic.Extentions;

namespace MvcBasicTests.Extentions
{
    [TestClass()]
    public class ReferrerAttributeTests
    {
        [TestMethod()]
        public void IsValidForRequestTest()
        {
            // Arrange
            var uri1 = new Uri("http://www.wings.msn.to/Test/Previous");
            var uri2 = new Uri("http://yahoo.co.jp/Member/Create");

            var context = new Mock<ControllerContext>();
            context.SetupGet<Uri>(c => c.HttpContext.Request.UrlReferrer).Returns(uri1);
            context.SetupGet<Uri>(c => c.HttpContext.Request.Url).Returns(uri2);

            var info = new Mock<MethodInfo>();
            var attr = new ReferrerAttribute(true);

            // Act
            var result = attr.IsValidForRequest(context.Object, info.Object);

            // Assert
            Assert.IsFalse(result);
        }
    }
}