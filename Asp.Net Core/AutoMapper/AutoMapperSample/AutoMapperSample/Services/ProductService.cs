using AutoMapper;
using AutoMapper.QueryableExtensions;
using AutoMapperSample.Contexts;
using AutoMapperSample.Dtos;
using AutoMapperSample.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoMapperSample.Services
{
    public class ProductService(IMapper mapper, AppDbContext context)
    {
        //In-Memory Mapping
        public ProductDto GetProduct()
        {
            var product = new Product
            {
                Id = 1,
                Name = "Laptop",
                Price = 1200,
                InternalCode = "SECRET-001",
                CreatedAt = DateTime.Now
            };
            var dto = mapper.Map<ProductDto>(product);
            return dto;
        }
        public Product CreateProduct(CreateProductDto dto)
        {
            var product = mapper.Map<Product>(dto);
            product.Id = 100;
            product.InternalCode = "AUTO-001";
            product.CreatedAt = DateTime.UtcNow;
            return product;
        }

        //Database Projection
        public async Task<List<ProductDto>> GetProductsAsync() => await context.Products
            .ProjectTo<ProductDto>(mapper.ConfigurationProvider)
            .ToListAsync();
        public async Task<ProductDto?> GetProductAsync(int id) => await context.Products
            .Where(p => p.Id == id)
            .ProjectTo<ProductDto>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();
        public async Task<Product> CreateProductAsync(CreateProductDto dto)
        {
            var product = mapper.Map<Product>(dto);
            context.Products.Add(product);
            await context.SaveChangesAsync();
            return product;
        }
    }
}
