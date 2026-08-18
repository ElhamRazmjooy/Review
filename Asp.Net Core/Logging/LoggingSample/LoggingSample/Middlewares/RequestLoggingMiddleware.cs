namespace LoggingSample.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        public async Task Invoke(HttpContext httpContext)
        {
            var requestId = Guid.NewGuid().ToString();
            httpContext.Items["RequestId"] = requestId;

            using var scope = logger.BeginScope(new Dictionary<string, object>
            {
                ["RequestId"] = requestId
            });
            logger.LogInformation("Request STARTED: {Method} {Path}", httpContext.Request.Method, httpContext.Request.Path);
            try
            {
                await next(httpContext);
                logger.LogInformation("Request FINISHED With StatusCode: {StatusCode}", httpContext.Response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unhandled exception occurred while processing request");
                throw;
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RequestLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLoggingMiddleware(this IApplicationBuilder builder) => 
            builder.UseMiddleware<RequestLoggingMiddleware>();
    }
}
