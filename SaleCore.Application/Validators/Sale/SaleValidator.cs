using FluentValidation;
using SaleCore.Application.Dtos.Sale.Request;

namespace SaleCore.Application.Validators.Sale
{
    public class SaleValidator : AbstractValidator<SaleRequestDto>
    {
        public SaleValidator()
        {
            RuleFor(x => x.VoucherNumber)
                .NotNull().WithMessage("El campo Número de voucher no puede ser nulo.")
                .NotEmpty().WithMessage("El campo Número de voucher no puede ser vacío");
        }
    }
}