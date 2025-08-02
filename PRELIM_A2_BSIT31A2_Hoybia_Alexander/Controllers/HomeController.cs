using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PRELIM_A2_BSIT31A2_Hoybia_Alexander.Models;

namespace PRELIM_A2_BSIT31A2_Hoybia_Alexander.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Privacy()
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
