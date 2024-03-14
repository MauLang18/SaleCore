using FluentValidation;
using SaleCore.Application.Dtos.Warehouse.Request;

namespace SaleCore.Application.Validators.Warehouse
{
    public class WarehouseValidator : AbstractValidator<WarehouseRequestDto>
    {
        public WarehouseValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("El campo Nombre no puede ser nulo.")
                .NotEmpty().WithMessage("El campo Nombre no puede ser vacío.");

        }
    }
}