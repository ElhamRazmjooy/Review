using MinimalApiSample.DTOs;
using MinimalApiSample.Models;

namespace MinimalApiSample.Services
{
    public class ProductService : IProductService
    {
        private readonly List<Product> products =
        [
            new Product
            {
                Id = 1,
                Name = "Laptop",
                Price = 50000
            },
            new Product
            {
                Id = 2,
                Name = "Mouse",
                Price = 1500
            }
        ];
        public List<ProductDto> GetAll() => products.Select(MapToDto).ToList();
        public ProductDto? GetById(int id) 
        {
            var product = products.FirstOrDefault(x => x.Id == id);

            return product is null ? null : MapToDto(product);
        } 
        public ProductDto Create(CreateProductDto dto)
        {
            var product = new Product
            {
                Id = products.Count + 1,
                Name = dto.Name,
                Price = dto.Price
            };
            products.Add(product);
            return MapToDto(product);
        }
        private static ProductDto MapToDto(Product product) => new ProductDto(product.Id, product.Name, product.Price);
    }
}
