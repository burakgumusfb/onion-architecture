using MediatR;
using Onion.Architecture.Application.Common.BaseModels;

namespace Application.Features.ProductOperations.Queries
{
    public class GetProductsQueryRequest : IRequest<ServiceResult<IReadOnlyList<GetProductsQueryResponse>>> { }
}