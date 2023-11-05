using DemoPage.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPage.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private ILogger<HomeController> _logger;

        [TestInitialize]
        public void Init()
        {
            _logger = Substitute.For<ILogger<HomeController>>(); 
        }


        [TestMethod]
        public void Index_ReturnsAViewResult()
        {
            // Arrange
            var controller = new HomeController(_logger);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = result as ViewResult;
            Assert.IsInstanceOfType(viewResult, typeof(ViewResult));
        }

        [TestMethod]
        public void Privacy_ReturnsAViewResult()
        {
            // Arrange
            var controller = new HomeController(_logger);

            // Act
            var result = controller.Privacy();

            // Assert
            var viewResult = result as ViewResult;
            Assert.IsInstanceOfType(viewResult, typeof(ViewResult));
        }

        [TestMethod]
        public void Error_ReturnsAViewResult()
        {
            // Arrange
            var controller = new HomeController(_logger);
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            // Act
            var result = controller.Error();

            // Assert
            var viewResult = result as ViewResult;
            Assert.IsInstanceOfType(viewResult, typeof(ViewResult));
        }
    }
}
