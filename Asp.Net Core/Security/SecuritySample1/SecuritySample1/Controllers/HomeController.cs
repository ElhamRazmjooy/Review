using Microsoft.AspNetCore.Mvc;
using SecuritySample1.Models;
using System.Diagnostics;

namespace SecuritySample1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IConfiguration Configuration { get; }
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            Configuration=configuration;
        }

        //Secret Manager
        //public string Index() => Configuration["Password"].ToString();

        //CSRF Attacks
        //public IActionResult Index() => View();

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
