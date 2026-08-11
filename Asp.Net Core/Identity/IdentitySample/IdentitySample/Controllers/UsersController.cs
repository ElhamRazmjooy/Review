using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentitySample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public IActionResult GetAll() => Ok(new
        {
            message = "You are Authenticated."
        });

        [Authorize(Policy = ("DeleteUser"))]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(new
            {
                message = $"User {id} Deleted."
            });
        }
    }
}
