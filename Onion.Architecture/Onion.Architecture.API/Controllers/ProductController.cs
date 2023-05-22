using Application.Features.ProductOperations.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Onion.Architecture.API.Controllers
{

    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {

        readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet("get-products")]
        public async Task<IActionResult> GetProducts([FromQuery] GetProductsQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}

