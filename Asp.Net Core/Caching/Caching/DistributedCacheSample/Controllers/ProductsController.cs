using DistributedCacheSample.Services;
using Microsoft.AspNetCore.Mvc;

namespace DistributedCacheSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(ProductService productService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetProducts() => Ok(await productService.GetProductsAsync());

        [HttpDelete("cache")]
        public async Task<IActionResult> ClearCache()
        {
            await productService.InvalidateCacheAsync();
            return Ok(new
            {
                Message = "Cache cleared successfully."
            });
        }
    }
}
