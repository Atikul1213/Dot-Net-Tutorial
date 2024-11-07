using FirstCoreMVCWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using System.Diagnostics;

namespace FirstCoreMVCWebApplication.Controllers
{
    [Route("Home")]
    //[EnableRateLimiting("FixedWindowPolicy")]
    [EnableRateLimiting("TokenBucketPolicy")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("")]
        [Route("/")]     // only those route work but home controller does not work
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("")]
        [Route("MyHome")]     // only those route work but home controller does not work
        [Route("MyHome/Index")]
        public IActionResult StartPage()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("Details/{id?}")]
        public string Details(int id)
        {
            return "Details() Action Method of HomeController, ID Value = " + id;
        }

        [HttpGet("~/About")]
        public string About(int id)
        {
            return "About() Action Method of HomeController";
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
