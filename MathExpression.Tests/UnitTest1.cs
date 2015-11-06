using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathExpression.Controllers;
using System.Web.Mvc;

namespace MathExpression.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AnswerView_Test()
        {
            var homeController = new HomeController();
            var result = homeController.Answer("5*5") as ViewResult;

            Assert.AreEqual("About",result.ViewName);
        }

        [TestMethod]
        public void AnswerViewBagEqual_Test()
        {
            var homeController = new HomeController();
            var result = homeController.Answer("2-1") as ViewResult;

            Assert.AreEqual("1", result.ViewBag.Response);
        }

        [TestMethod]
        public void AnswerViewBagNull_Test()
        {
            var homeController = new HomeController();
            var result = homeController.Answer("5*5") as ViewResult;

            Assert.IsNotNull(result.ViewBag.Response);

        }

    }
}
