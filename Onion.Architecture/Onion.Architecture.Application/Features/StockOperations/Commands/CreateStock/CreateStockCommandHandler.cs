using AutoMapper;
using MediatR;
using Onion.Architecture.Application.Common.BaseModels;
using Onion.Architecture.Application.Features.StockOperations.Commands.CreateStock;
using Onion.Architecture.Application.Interfaces;
using Onion.Architecture.Domain.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Architecture.Application.Features.ProductOperations.Commands.CreateProduct
{
    public class CreateStockCommandHandler : IRequestHandler<CreateStockCommandRequest, ServiceResult<CreateStockCommandResponse>>
    {
        private readonly IUnitofWork _uow;
        private readonly IProductAppService _productAppService;
        private readonly IStockAppService _stockAppService;
        private readonly IMapper _mapper;
        public CreateStockCommandHandler(
            IUnitofWork uow,
            IStockAppService stockAppService,
            IProductAppService productAppService,
            IMapper mapper
        )
        {
            _uow = uow;
            _productAppService = productAppService;
            _stockAppService = stockAppService;
            _mapper = mapper;
        }
        public async Task<ServiceResult<CreateStockCommandResponse>> Handle(CreateStockCommandRequest request, CancellationToken cancellationToken)
        {
            var serviceResult = new ServiceResult<CreateStockCommandResponse>();
            await this._uow.BeginTransactionAsync();
            await _stockAppService.CreateAsync(new Stock(request.ProductId, request.Quantity));
            await this._uow.CommitAsync();

            return serviceResult;
        }
    }
}