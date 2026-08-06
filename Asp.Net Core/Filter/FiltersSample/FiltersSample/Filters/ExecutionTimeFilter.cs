using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace FiltersSample.Filters
{
    public class ExecutionTimeFilter : IActionFilter
    {
        private Stopwatch? _stopwatch;
        public void OnActionExecuting(ActionExecutingContext context) => _stopwatch = Stopwatch.StartNew();
        public void OnActionExecuted(ActionExecutedContext context)
        {
            _stopwatch?.Stop();
            Console.WriteLine($"Execution Time: {_stopwatch?.ElapsedMilliseconds}ms");
        }
    }
}
