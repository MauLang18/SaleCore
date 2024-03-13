using FluentValidation;
using SaleCore.Application.Dtos.Provider.Request;

namespace SaleCore.Application.Validators.Provider
{
    public class ProviderValidator : AbstractValidator<ProviderRequestDto>
    {
        public ProviderValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("El campo Nombre no puede ser nulo.")
                .NotEmpty().WithMessage("El campo Nombre no puede ser vacío.");
        }
    }
}