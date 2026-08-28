using MediatR;
using MediatRSample.Application.Products.Commands;
using MediatRSample.Application.Products.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MediatRSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await mediator.Send(new GetProductsQuery()));

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command) => CreatedAtAction(nameof(Get), 
            await mediator.Send(command));
            
    }
}
