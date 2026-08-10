using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SqlInjectionSample.Models;
using System.Diagnostics;

namespace SqlInjectionSample.Controllers
{
    public class HomeController(ILogger<HomeController> logger, IConfiguration configuration) : Controller
    {
        private readonly IConfiguration _configuration = configuration;
        private readonly ILogger<HomeController> _logger = logger;

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string userName, string password)
        {
            // Use reCAPTCHA
            var googleResponse = HttpContext.Request.Form["g-recaptcha-response"];
            if (!(new GoogleRecaptcha().Verify(googleResponse)))
            {
                ViewBag.Message = "تأیید کنید ربات نیستید!";
                return View();
            }

            List<string> blackList = new() 
            {
                "--", "or", "and", "=", "/*", "*/", "@@", "@", "char", "nchar", "varchar", "nvarchar", "alter", "begin"
            };
            var passwordCheck = blackList.FirstOrDefault(x => password.ToUpper().Contains(x.ToUpper()));
            if (passwordCheck != null)
            {
                ViewBag.Message = "احتمال هک شدن";
                return View();
            }
            var userNameCheck = blackList.FirstOrDefault(x => userName.ToUpper().Contains(x.ToUpper()));
            if (userNameCheck != null)
            {
                ViewBag.Message ="احتمال هک شدن";
                return View();
            }

            SqlConnection connection = new(_configuration.GetConnectionString("Cs"));
            connection.Open();
            SqlCommand command = new($"SELECT * FROM USERS WHERE USERNAME = '{userName}' AND PASSWORD = '{password}'",
                connection);
            var result = command.ExecuteReader();
            if (result.Read())
            {
                ViewBag.Message = "ورود باموفقیت انجام شد";
                return View();
            }
            ViewBag.Message = "ورود ناموفق";
            return View();
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
