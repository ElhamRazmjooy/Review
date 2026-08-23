using MemoryCacheSample.Services;
using Microsoft.AspNetCore.Mvc;

namespace MemoryCacheSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(ProductService productService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetProducts() => Ok(await productService.GetProductsAsync());

        [HttpDelete("cache")]
        public IActionResult ClearCache()
        {
            productService.InvalidateProductsCache();
            return Ok(new
            {
                Message = "Cache cleared successfully."
            });
        }
    }
}
