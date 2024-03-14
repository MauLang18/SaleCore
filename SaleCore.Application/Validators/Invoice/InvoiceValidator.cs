using FluentValidation;
using SaleCore.Application.Dtos.Invoice.Request;

namespace SaleCore.Application.Validators.Invoice
{
    public class InvoiceValidator : AbstractValidator<InvoiceRequestDto>
    {
        public InvoiceValidator()
        {
            RuleFor(x => x.VoucherNumber)
                .NotNull().WithMessage("El campo Número de voucher no puede ser nulo.")
                .NotEmpty().WithMessage("El campo Número de voucher no puede ser vacío");
        }
    }
}