using Application.Features.ProductOperations.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Onion.Architecture.Application.Features.ProductOperations.Commands.CreateProduct;

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
        
        [HttpPost("create-product")]
        public async Task<IActionResult> CreateProduct(CreateProductCommandRequest request)
        {
            var createProductCommand = new CreateProductCommandValidator();

            var result = createProductCommand.Validate(request);

            if (result.IsValid)
            {
                var response = await _mediator.Send(request);
                return Ok(response);
            }

            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
            return BadRequest(errorMessages);

        }
    }
}

