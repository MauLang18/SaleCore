using FluentValidation;
using SaleCore.Application.Dtos.VoucherDocumentType.Request;

namespace SaleCore.Application.Validators.VoucherDocumentType
{
    public class VoucherDocumentTypeValidator : AbstractValidator<VoucherDocumentTypeRequestDto>
    {
        public VoucherDocumentTypeValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("El campo Nombre no puede ser nulo.")
                .NotEmpty().WithMessage("El campo Nombre no puede ser vacío.");
        }
    }
}