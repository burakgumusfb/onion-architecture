using AutoMapper;
using MediatR;
using Onion.Architecture.Application.Common.BaseModels;
using Onion.Architecture.Application.Interfaces;

namespace Application.Features.ProductOperations.Queries
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQueryRequest, ServiceResult<IReadOnlyList<GetProductsQueryResponse>>>
    {
        private readonly IProductAppService _productAppService;
        private readonly IMapper _mapper;

        public GetProductsQueryHandler(IProductAppService productAppService, IMapper mapper)
        {
            _productAppService = productAppService;
            _mapper = mapper;
        }

        public async Task<ServiceResult<IReadOnlyList<GetProductsQueryResponse>>> Handle(GetProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var serviceResult = new ServiceResult<IReadOnlyList<GetProductsQueryResponse>>();
            var products = await _productAppService.GetProducts();
            serviceResult.ResultObject = _mapper.Map<IReadOnlyList<GetProductsQueryResponse>>(products.ResultObject);
            return serviceResult;    
        } 
    }
}