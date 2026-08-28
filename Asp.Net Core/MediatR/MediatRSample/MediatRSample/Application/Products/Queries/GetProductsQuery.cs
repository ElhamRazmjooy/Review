using MediatR;
using MediatRSample.Application.Products.DTOs;

namespace MediatRSample.Application.Products.Queries
{
    public record GetProductsQuery : IRequest<List<ProductDto>>;
}
