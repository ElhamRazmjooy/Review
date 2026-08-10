using System.Net;

namespace SafeIPSample.Models
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class SafeIPMiddleware(RequestDelegate next, string iPAddressSafe)
    {
        private readonly RequestDelegate _next = next;
        private readonly string _iPAddressSafe = iPAddressSafe;
        public async Task Invoke(HttpContext httpContext)
        {
            var userIP = httpContext.Connection.RemoteIpAddress;
            string[] safeIP = _iPAddressSafe.Split(';');
            var userIPBytes = userIP.GetAddressBytes();
            var isBlock = true;
            foreach (var item in safeIP)
            {
                var tempIP = IPAddress.Parse(item);
                if (tempIP.GetAddressBytes().SequenceEqual(userIPBytes))
                {
                    isBlock = false; 
                    break;
                }
            }
            if (isBlock)
            {
                httpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
                return;
            }
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class SafeIPMiddlewareExtensions
    {
        public static IApplicationBuilder UseSafeIPMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SafeIPMiddleware>();
        }
    }
}
