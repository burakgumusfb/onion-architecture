using MediatR;
using Onion.Architecture.Application.Common.BaseModels;
using Onion.Architecture.Application.Features.ProductOperations.Commands.CreateProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Architecture.Application.Features.StockOperations.Commands.CreateStock
{
    public class CreateStockCommandRequest : IRequest<ServiceResult<CreateStockCommandResponse>>
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}