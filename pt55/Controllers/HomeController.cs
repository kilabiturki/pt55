using Microsoft.AspNetCore.Mvc;
using pt55.Models;
using System.Diagnostics;

namespace pt55.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

 

        public ActionResult Advices()
        {
            return View();
        }

        public IActionResult Diseases()
        {
            return View();
        }

        public IActionResult Locations()
        {
            return View();
        }

        public IActionResult Clips()
        {
            return View();
        }


        public IActionResult First()
        {
           
            return View();
        }

        public IActionResult Search()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}