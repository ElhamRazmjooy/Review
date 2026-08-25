using ConcurrencySample02.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConcurrencySample02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConcurrencyController(ConcurrencyService service) : ControllerBase
    {

        [HttpGet("parallel")]
        public async Task<IActionResult> Parallel(CancellationToken cancellationToken) => 
            Ok(await service.RunParallelTasksAsync(cancellationToken));

        [HttpGet("critical")]
        public async Task<IActionResult> Critical(CancellationToken cancellationToken) =>
            Ok(await service.CriticalSectionAsync(cancellationToken));

        [HttpGet("counter")]
        public async Task<IActionResult> Counter(CancellationToken cancellationToken) => Ok(new
        {
            Counter = await service.IncrementCounterAsync(cancellationToken)
        });
    }
}

