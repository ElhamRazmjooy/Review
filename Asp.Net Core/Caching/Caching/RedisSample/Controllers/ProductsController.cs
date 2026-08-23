using Microsoft.AspNetCore.Mvc;
using RedisCacheSample.Services;

namespace RedisCacheSample.Controllers
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
                Message = "Redis cache cleared successfully."
            });
        }
    }
}
