using BackgroundServiceSample.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackgroundServiceSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService userService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken) => Ok(
            await userService.GetAllAsync(cancellationToken));
    }
}
