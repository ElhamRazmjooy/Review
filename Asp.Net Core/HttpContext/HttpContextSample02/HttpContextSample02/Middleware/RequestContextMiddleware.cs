namespace HttpContextSample02.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RequestContextMiddleware(RequestDelegate next)
    {
        public async Task Invoke(HttpContext httpContext)
        {
            var requestId = Guid.NewGuid().ToString();

            httpContext.Items["RequestId"] = requestId;
            httpContext.Items["StartTime"] = DateTime.UtcNow;

            httpContext.Response.Headers["X-Request-Id"] = requestId;

            Console.WriteLine("*REQUEST START*");
            Console.WriteLine($"Method: {httpContext.Request.Method}");
            Console.WriteLine($"Path: {httpContext.Request.Path}");
            Console.WriteLine($"IP: {httpContext.Connection.RemoteIpAddress}");

            await next(httpContext);

            Console.WriteLine($"Status Code: {httpContext.Response.StatusCode}");
            Console.WriteLine("*REQUEST END*");
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RequestContextMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestContextMiddleware(this IApplicationBuilder builder) => 
            builder.UseMiddleware<RequestContextMiddleware>();
    }
}
