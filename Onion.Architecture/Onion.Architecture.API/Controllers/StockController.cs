using Application.Features.ProductOperations.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Onion.Architecture.Application.Features.ProductOperations.Commands.CreateProduct;
using Onion.Architecture.Application.Features.StockOperations.Commands.CreateProduct;
using Onion.Architecture.Application.Features.StockOperations.Commands.CreateStock;

namespace Onion.Architecture.API.Controllers
{

    [ApiController]
    [Route("api/stock")]
    public class StockController : ControllerBase
    {
        readonly IMediator _mediator;
        public StockController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        
        [HttpPost("create-stock")]
        public async Task<IActionResult> CreateStock(CreateStockCommandRequest request)
        {
            var createStockCommand = new CreateStockCommandValidator();

            var result = createStockCommand.Validate(request);

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

