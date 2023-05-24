

using FluentValidation;
using Onion.Architecture.Application.Features.StockOperations.Commands.CreateStock;

namespace Onion.Architecture.Application.Features.StockOperations.Commands.CreateProduct
{
public class CreateStockCommandValidator : AbstractValidator<CreateStockCommandRequest>
    {
        public CreateStockCommandValidator()
        {
            RuleFor(p => p.ProductId)
                .GreaterThan(0)
                .WithMessage("Lütfen product alanını boş geçmeyiniz."); 
                
            RuleFor(p => p.Quantity)
                .GreaterThan(0)
                .WithMessage("Lütfen miktar alanını boş geçmeyiniz.");
        }
    }
}