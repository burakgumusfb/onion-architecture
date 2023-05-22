

using FluentValidation;

namespace Onion.Architecture.Application.Features.ProductOperations.Commands.CreateProduct
{
public class CreateProductCommandValidator : AbstractValidator<CreateProductCommandRequest>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.ProductCode)
                .NotNull()
                .WithMessage("Lütfen 'ProductCode'i boş geçmeyiniz.")
                .MaximumLength(20)
                .MinimumLength(3)
                .WithMessage("'ProductCode' değeri 3 ile 20 karakter arasında olmalıdır.");
        }
    }
}