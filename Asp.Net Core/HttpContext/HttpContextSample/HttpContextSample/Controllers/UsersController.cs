using Microsoft.AspNetCore.Mvc;

namespace HttpContextSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var method = HttpContext.Request.Method;
            var path = HttpContext.Request.Path;
            var token = HttpContext.Request.Headers["Authorization"].ToString();
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString();
            var startTime = HttpContext.Items["StartTime"];
            var userName = HttpContext.User.Identity?.Name;
            HttpContext.Response.Cookies.Append("MyCookie", "12345");
            var page = HttpContext.Request.Query["page"];
            var name = HttpContext.Request.Query["name"];
            return Ok(new
            {
                Method = method,
                Path = path,
                Token = token,
                IP = ip,
                StartTime = startTime,
                UserName = userName,
                Page = page,
                Name = name
            });
        }
    }
}
