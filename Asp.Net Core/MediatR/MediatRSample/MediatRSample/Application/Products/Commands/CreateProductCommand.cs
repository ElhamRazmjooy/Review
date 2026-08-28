using MediatR;
using MediatRSample.Application.Products.DTOs;

namespace MediatRSample.Application.Products.Commands
{
    public record CreateProductCommand(string Name, decimal Price) : IRequest<ProductDto>;
}
