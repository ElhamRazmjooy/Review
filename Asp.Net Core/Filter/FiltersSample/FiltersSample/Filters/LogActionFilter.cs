using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersSample.Filters
{
    public class LogActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.Controller.GetType().Name;
            var action = context.ActionDescriptor.RouteValues["action"];
            Console.WriteLine($"Before Action: {controller}.{action}");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var controller = context.Controller.GetType().Name;
            var action = context.ActionDescriptor.RouteValues["action"];
            Console.WriteLine($"After Action: {controller}.{action}");
        }
    }
}
