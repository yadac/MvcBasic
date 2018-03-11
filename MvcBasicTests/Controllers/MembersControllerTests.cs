using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcBasic.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MvcBasic.Models;

namespace MvcBasic.Controllers.Tests
{
    [TestClass()]
    public class MembersControllerTests
    {
        private MembersController _ctrl;

        [TestInitialize]
        public void MyTestInitialize()
        {
            // テスト用のリポジトリをコントローラに設定
            _ctrl = new MembersController(new MemberTestRepository());
        }

        [TestMethod()]
        public void IndexTest()
        {
            // Arrange

            // Act
            var result = _ctrl.Index() as ViewResult;

            // Assert
            var list = (IEnumerable<Member>) result.Model;
        }

        [TestMethod()]
        public void CreateTest1()
        {
            // Arrange

            // Act
            var result = _ctrl.Create(new Member()
            {
                Id = 10,
                Name = "taro",
                Email = "taro@example.com",
                Birth = new DateTime(2010, 1, 2),
                Married = false,
                Memo = "common name",
            });

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }
   }
}