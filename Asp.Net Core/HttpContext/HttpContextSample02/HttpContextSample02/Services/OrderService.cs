using HttpContextSample02.Models;

namespace HttpContextSample02.Services
{
    public class OrderService(IHttpContextAccessor contextAccessor)
    {
        public Order CreateOrder(Order order)
        {
            var context = contextAccessor.HttpContext;
            var requestId = context?.Items["RequestId"]?.ToString();
            var userId = context?.User.FindFirst("UserId")?.Value;
            var ip = context?.Connection.RemoteIpAddress?.ToString();

            Console.WriteLine($"Creating Order | RequestId: {requestId}");
            Console.WriteLine($"UserId: {userId}");
            Console.WriteLine($"IP: {ip}");

            return order;
        }
    }
}
