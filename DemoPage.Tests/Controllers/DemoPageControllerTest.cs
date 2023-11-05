using DemoPage.Controllers;
using DemoPage.Repository.Entities;
using DemoPage.Service.OgImageServices;
using DemoPage.Service.OgImageServices.Interfaces;
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
    public class DemoPageControllerTest
    {
        private ILogger<DemoPageController> _logger;
        private IOgImageService _ogImageService;

        [TestInitialize]
        public void Init()
        {
            _logger = Substitute.For<ILogger<DemoPageController>>();
            _ogImageService = Substitute.For<IOgImageService>();
        }

        [DataRow("1A")]
        [DataRow(null, DisplayName = "DemoPage Name is null")]
        [TestMethod]
        public async Task Index_ReturnsAViewResult(string? demoPageName)
        {
            // Arrange
            _ogImageService.GetOgImagesAsync().Returns(
                new List<OgImage>()
                {
                    new OgImage()
                    {
                        Id = 1,
                        Name = "1A",
                        Ext = ".jpg",
                        LocalExt = string.Empty,
                        LocalMirrorFile = true
                    },
                    new OgImage()
                    {
                        Id = 2,
                        Name = "2B",
                        Ext = string.Empty,
                        LocalExt = ".png",
                        LocalMirrorFile = false
                    },
                    new OgImage()
                    {
                        Id = 3,
                        Name = "3B",
                        Ext = ".jpg",
                        LocalExt = ".png",
                        LocalMirrorFile = false
                    },
                    new OgImage()
                    {
                        Id = 4,
                        Name = "4A",
                        Ext = ".jpg",
                        LocalExt = ".gif",
                        LocalMirrorFile = false
                    },
                    new OgImage()
                    {
                        Id = 5,
                        Name = "5C",
                        Ext = string.Empty,
                        LocalExt = string.Empty,
                        LocalMirrorFile = true
                    }
                });

            var controller = new DemoPageController(
                _logger,
                _ogImageService
                );

            // Act
            var result = await controller.Index(demoPageName);

            // Assert
            var viewResult = result as ViewResult;
            Assert.IsInstanceOfType(viewResult, typeof(ViewResult));
        }
    }
}
