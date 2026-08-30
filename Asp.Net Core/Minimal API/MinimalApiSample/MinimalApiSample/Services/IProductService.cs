using MinimalApiSample.DTOs;

namespace MinimalApiSample.Services
{
    public interface IProductService
    {
        List<ProductDto> GetAll();
        ProductDto? GetById(int id);
        ProductDto Create(CreateProductDto dto);
    }
}
