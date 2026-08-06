using FiltersSample.Filters;
using FiltersSample.Models;
using Microsoft.AspNetCore.Mvc;

namespace FiltersSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private static readonly List<User> users =
        [
            new User
            {
                Id = 1,
                Name = "Ali",
                Age = 25
            },
            new User
            {
                Id = 2,
                Name = "Sara",
                Age = 30
            }
        ];

        [HttpGet]
        public IActionResult GetAll() => Ok(users);

        [HttpGet("{id}")]
        public IActionResult GetById(int id) => users.FirstOrDefault(x => x.Id == id) == null ? NotFound() : Ok(users.FirstOrDefault(x => x.Id == id));

        [HttpPost]
        [CustomLog]
        public IActionResult Add(User user)
        {
            users.Add(user);
            return Ok(user);
        }

        [HttpGet("error")]
        public IActionResult Error() => throw new Exception("Something went wrong.");
    }
}
