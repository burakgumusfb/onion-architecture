using AutoMapper;
using MediatR;
using Onion.Architecture.Application.Interfaces;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Architecture.Application.Features.ProductOperations.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly IProductAppService _productAppService;
        private readonly IMapper _mapper;
        public CreateProductCommandHandler(IProductAppService productAppService, IMapper mapper)
        {
            _productAppService = productAppService;
            _mapper = mapper;
        }
        public Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            throw new Exception();  
        }
    }
}