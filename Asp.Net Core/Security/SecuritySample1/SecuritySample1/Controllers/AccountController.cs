using Microsoft.AspNetCore.Mvc;
using SecuritySample1.Models.Dto;

namespace SecuritySample1.Controllers
{
    //Open Redirect Attacks
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            ModelState.AddModelError("", "نام کاربری اشتباه است");
            return View(new LoginDto
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public IActionResult Login(LoginDto login) => Redirect(login.ReturnUrl);
    }
}
