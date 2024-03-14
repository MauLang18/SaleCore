using FluentValidation;
using SaleCore.Application.Dtos.Quote.Request;

namespace SaleCore.Application.Validators.Quote
{
    public class QuoteValidator : AbstractValidator<QuoteRequestDto>
    {
        public QuoteValidator()
        {
            RuleFor(x => x.VoucherNumber)
                .NotNull().WithMessage("El campo Número de voucher no puede ser nulo.")
                .NotEmpty().WithMessage("El campo Número de voucher no puede ser vacío");
        }
    }
}