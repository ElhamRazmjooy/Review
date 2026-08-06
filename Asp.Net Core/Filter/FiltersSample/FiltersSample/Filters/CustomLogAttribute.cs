using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersSample.Filters
{
    public class CustomLogAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Custom Log: Action Started.");
            base.OnActionExecuting(context);
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Custom Log: Action Finished.");
            base.OnActionExecuted(context);
        }
    }
}
