using LoggingSample.Services;
using Microsoft.AspNetCore.Mvc;

namespace LoggingSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController(ILogger<OrdersController> logger, OrderService orderService) : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            logger.LogInformation("Get Order Request Received for {OrderId}", id);
            try
            {
                return Ok(orderService.GetOrder(id));
            }
            catch (ArgumentException ex)
            {
                logger.LogError(ex, "Failed to Get Order {OrderId}", id);
                return BadRequest(ex.Message);
            }
        }
    }
}
