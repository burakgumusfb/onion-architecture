using AutoMapper;
using MediatR;
using Onion.Architecture.Application.Common.BaseModels;
using Onion.Architecture.Application.Interfaces;
using Onion.Architecture.Domain.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Architecture.Application.Features.ProductOperations.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, ServiceResult<CreateProductCommandResponse>>
    {
        private readonly IUnitofWork _uow;
        private readonly IProductAppService _productAppService;
        private readonly IStockAppService _stockAppService;
        private readonly IMapper _mapper;
        public CreateProductCommandHandler(
            IUnitofWork uow,
            IStockAppService stockAppService,
            IProductAppService productAppService,

        IMapper mapper)
        {
            _uow = uow;
            _productAppService = productAppService;
            _stockAppService = stockAppService;
            _mapper = mapper;
        }
        public async Task<ServiceResult<CreateProductCommandResponse>> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var serviceResult = new ServiceResult<CreateProductCommandResponse>();
            
            await this._uow.BeginTransactionAsync();

            var productId = await _productAppService.CreateAsync(new Product(request.ProductCode, request.ProductName));
            var stockId = await _stockAppService.CreateAsync(new Stock(productId, request.StockQuantity));

            await this._uow.CommitAsync();
            return serviceResult;
        }
    }
}