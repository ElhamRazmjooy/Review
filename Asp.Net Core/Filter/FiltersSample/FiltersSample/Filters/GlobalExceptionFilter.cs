using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersSample.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            Console.WriteLine($"Exception: {exception.Message}");
            context.Result = new ObjectResult(
                new
                {
                    Success = false,
                    Message = "An error occurred.",
                    Details = exception.Message
                })
            {
                StatusCode = 500
            };
            context.ExceptionHandled = true;
        }
    }
}
