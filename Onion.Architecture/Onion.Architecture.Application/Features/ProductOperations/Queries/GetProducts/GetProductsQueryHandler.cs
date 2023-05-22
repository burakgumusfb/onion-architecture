using AutoMapper;
using MediatR;
using Onion.Architecture.Application.Interfaces;

namespace Application.Features.ProductOperations.Queries;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQueryRequest, IReadOnlyList<GetProductsQueryResponse>>
{
     private readonly IProductAppService _productAppService;
     private readonly IMapper _mapper;

     public GetProductsQueryHandler(IProductAppService productAppService, IMapper mapper)
     {
          _productAppService = productAppService;
          _mapper = mapper;
     }

     public async Task<IReadOnlyList<GetProductsQueryResponse>> Handle(GetProductsQueryRequest request, CancellationToken cancellationToken)
     {
    
          var products = await _productAppService.GetProducts();

          return _mapper.Map<IReadOnlyList<GetProductsQueryResponse>>(products);
     }
}