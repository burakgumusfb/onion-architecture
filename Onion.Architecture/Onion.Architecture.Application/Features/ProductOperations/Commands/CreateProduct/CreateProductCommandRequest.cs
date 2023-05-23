using MediatR;
using Onion.Architecture.Application.Common.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Architecture.Application.Features.ProductOperations.Commands.CreateProduct
{
    public class CreateProductCommandRequest : IRequest<ServiceResult<CreateProductCommandResponse>>
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int StockQuantity { get; set; }
    }
}