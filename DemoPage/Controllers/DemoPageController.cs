using Microsoft.AspNetCore.Mvc;

namespace DemoPage.Controllers
{
    public class DemoPageController : Controller
    {
        private readonly ILogger<DemoPageController> _logger;

        public DemoPageController(
            ILogger<DemoPageController> logger
            )
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
