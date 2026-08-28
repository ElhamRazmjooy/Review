using MediatR;
using MediatRSample.Infrastructure;
using Microsoft.EntityFrameworkCore;
using MediatRSample.Application.Products.DTOs;

namespace MediatRSample.Application.Products.Queries
{
    public class GetProductsQueryHandler(AppDbContext context) 
        : IRequestHandler<GetProductsQuery, List<ProductDto>>
    {
        public async Task<List<ProductDto>> Handle(GetProductsQuery request,
            CancellationToken cancellationToken) => await context.Products.Select(x => new ProductDto
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price
            }).ToListAsync(cancellationToken);
    }
}
