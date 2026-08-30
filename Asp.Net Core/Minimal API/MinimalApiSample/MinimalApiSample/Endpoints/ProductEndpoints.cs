using MinimalApiSample.DTOs;
using MinimalApiSample.Services;

namespace MinimalApiSample.Endpoints
{
    public static class ProductEndpoints
    {
        public static void MapProductEndpoints(this WebApplication app)
        {
            var products = app.MapGroup("api/products");
            products.MapGet("/", (IProductService service) =>
            {
                return Results.Ok(service.GetAll());
            });
            products.MapGet("/{id:int}", (int id, IProductService service) =>
            {
                var product = service.GetById(id);
                return product is null ? Results.NotFound() : Results.Ok(product);
            });
            products.MapPost("/", (CreateProductDto dto, IProductService service) =>
            {
                var product = service.Create(dto);
                return Results.Created($"api/product/{product.Id}", product);
            });
        }
    }
}
