
namespace HttpContextSample.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RequestInfoMiddleware(RequestDelegate next)
    {
        public async Task Invoke(HttpContext httpContext)
        {
            var startTime = DateTime.Now;
            httpContext.Items["StartTime"] = startTime;
            Console.WriteLine($"Method: {httpContext.Request.Method}");
            Console.WriteLine($"Path: {httpContext.Request.Path}");
            await next(httpContext);
            Console.WriteLine($"Status Code: {httpContext.Response.StatusCode}");
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RequestInfoMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestInfoMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestInfoMiddleware>();
        }
    }
}
