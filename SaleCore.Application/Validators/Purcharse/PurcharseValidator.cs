using FluentValidation;
using SaleCore.Application.Dtos.Purcharse.Request;

namespace SaleCore.Application.Validators.Purcharse
{
    public class PurcharseValidator : AbstractValidator<PurcharseRequestDto>
    {
        public PurcharseValidator()
        {
            RuleFor(x => x.ProviderId)
                .NotNull().WithMessage("El campo Proveedor no puede ser nulo.")
                .NotEmpty().WithMessage("El campo Proveedor no puede ser vacío");
        }
    }
}