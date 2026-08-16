using EventApiSample.Models;
using EventApiSample.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventApiSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(UserService userService) : ControllerBase
    {
        [HttpPost]
        public IActionResult Register(User user) => Ok(userService.Register(user));
    }
}
