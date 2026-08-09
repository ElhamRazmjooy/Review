using Ganss.Xss;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using XssSample.Context;
using XssSample.Models;
using XssSample.Models.Entities;

namespace XssSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly XssContext _context;
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger, XssContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            CookieOptions cookieOptions = new()
            {
                Expires = DateTime.Now.AddDays(10),
                HttpOnly = true 
            };
            Response.Cookies.Append("MyCookies", "This is a Test Value");
            var sanitizer = new HtmlSanitizer();
            return View(_context.Comments.OrderByDescending(x => x.Id).ToList().Select(x => new Comment
            {
                Id = x.Id,
                Name = x.Name,
                Body = sanitizer.Sanitize(x.Body),
            }));
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SendComment(Comment comment)
        {
            var sanitizer = new HtmlSanitizer();
            var result = sanitizer.Sanitize(comment.Body);
            _context.Comments.Add(comment);
            _context.SaveChanges();
            return RedirectToAction("Index");
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
