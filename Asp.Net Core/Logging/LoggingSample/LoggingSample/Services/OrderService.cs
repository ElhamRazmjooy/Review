using LoggingSample.Models;

namespace LoggingSample.Services
{
    public class OrderService(ILogger<OrderService> logger)
    {
        private static readonly EventId OrderCreatedEvent = new(1001, "OrderCreated");
        public Order GetOrder(int id)
        {
            logger.LogInformation("Getting Order {OrderId}", id);
            if (id <= 0)
            {
                logger.LogWarning("Invalid Order Id Received: {OrderId}", id);
                throw new ArgumentException("Order id must be greater than zero.");
            }
            var order = new Order()
            {
                Id = id,
                Product = "Laptop",
                Price = 45000
            };
            logger.LogInformation(OrderCreatedEvent, "Order {OrderId} retrieved successfully", order.Id);
            return order;
        }
    }
}
