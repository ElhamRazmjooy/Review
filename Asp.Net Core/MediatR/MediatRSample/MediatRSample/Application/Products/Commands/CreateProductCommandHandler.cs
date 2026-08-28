using MediatR;
using MediatRSample.Infrastructure;
using MediatRSample.Domain;
using MediatRSample.Application.Products.DTOs;

namespace MediatRSample.Application.Products.Commands
{
    public class CreateProductCommandHandler(AppDbContext context) 
        : IRequestHandler<CreateProductCommand, ProductDto>
    {
        public async Task<ProductDto> Handle(CreateProductCommand request,
            CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Price = request.Price,
            };
            context.Products.Add(product);
            await context.SaveChangesAsync(cancellationToken);
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }
    }
}
