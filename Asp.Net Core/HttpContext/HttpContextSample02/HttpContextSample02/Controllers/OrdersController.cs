using HttpContextSample02.Models;
using HttpContextSample02.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HttpContextSample02.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController(OrderService orderService) : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetOrder(int id, [FromQuery] string? search)
        {
            var routeId = HttpContext.Request.RouteValues["id"];
            var querySearch = HttpContext.Request.Query["search"];
            var clientVersion = HttpContext.Request.Headers["X-Client-Version"].ToString();
            var authorization = HttpContext.Request.Headers["Authorization"].ToString();
            var userId = HttpContext.User.FindFirst("UserId")?.Value;
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString();
            var requestId = HttpContext.Items["RequestId"]?.ToString();
            var theme = HttpContext.Request.Cookies["Theme"];

            return Ok(new
            {
                RouteId = routeId,
                Search = querySearch.ToString(),
                ClientVersion = clientVersion,
                Authorization = authorization,
                UserId = userId,
                IP = ip,
                RequestId = requestId,
                Theme = theme
            });
        }

        [HttpPost]
        public IActionResult CreateOrder(Order order) => CreatedAtAction(nameof(CreateOrder), 
            orderService.CreateOrder(order));
    }
}
