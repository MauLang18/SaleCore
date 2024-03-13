using FluentValidation;
using SaleCore.Application.Dtos.Client.Request;

namespace SaleCore.Application.Validators.Client
{
    public class ClientValidator : AbstractValidator<ClienteRequestDto>
    {
        public ClientValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("El campo Nombre no puede ser nulo.")
                .NotEmpty().WithMessage("El campo Nombre no puede ser vacío.");
        }
    }
}