using AutoMapperSample.Dtos;
using AutoMapperSample.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapperSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(ProductService service) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok(service.GetProduct());

        [HttpPost]
        public IActionResult Create(CreateProductDto dto)
        {
            var product = service.CreateProduct(dto);
            return CreatedAtAction(nameof(Get), product);
        }
       
        [HttpGet("GetAsync")]
        public async Task<IActionResult> GetAsync() => Ok(await service.GetProductsAsync());

        [HttpGet(("{id}"),Name = "GetProductById")]
        public async Task<IActionResult> GetProductByIdAsync(int id)
        {
            var product = await service.GetProductAsync(id);
            return product == null ? NotFound() : Ok(product);
        }

        [HttpPost("CreateAsync")]
        public async Task<IActionResult> CreateAsync(CreateProductDto dto)
        {
            var product = await service.CreateProductAsync(dto);
            return CreatedAtRoute("GetProductById", new { id = product.Id }, product);
        }
    }
}
