using DemoPage.Models;
using DemoPage.Repository.Entities;
using DemoPage.Service.OgImageServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DemoPage.Controllers
{
    public class DemoPageController : Controller
    {
        private readonly ILogger<DemoPageController> _logger;
        private readonly IOgImageService _ogImageService;

        public DemoPageController(
            ILogger<DemoPageController> logger,
            IOgImageService ogImageService
            )
        {
            _logger = logger;
            _ogImageService = ogImageService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string? name)
        {
            DemoPageViewModel model = new();

            List<OgImage> images = await _ogImageService.GetOgImagesAsync();

            if (string.IsNullOrWhiteSpace(name) )
            {
                model.OgImage = images.FirstOrDefault();
            }
            else
            {
                model.OgImage = images.SingleOrDefault(o => o.Name == name);
            }

            return View(model);
        }
    }
}
