using FluentValidation;
using SaleCore.Application.Dtos.Product.Request;

namespace SaleCore.Application.Validators.Product
{
    public class ProductValidator : AbstractValidator<ProductRequestDto>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("El campo Nombre no puede ser nulo.")
                .NotEmpty().WithMessage("El campo Nombre no puede ser vacío.");
        }
    }
}