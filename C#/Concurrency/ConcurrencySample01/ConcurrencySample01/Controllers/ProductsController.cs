using ConcurrencySample.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ConcurrencySample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(ProductService productService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var stopwatch = Stopwatch.StartNew();
            var products = await productService.GetProductsAsync();
            stopwatch.Stop();
            return Ok(new
            { 
                Products = products,
                stopwatch.ElapsedMilliseconds
            });
        }

        [HttpGet("critical")]
        public async Task<IActionResult> CriticalOperation() => Ok(await productService.CriticalOperationAsync());
    }
}
