using FluentValidation;
using SaleCore.Application.Dtos.DocumentType.Request;

namespace SaleCore.Application.Validators.DocumentType
{
    public class DocumentTypeValidator : AbstractValidator<DocumentTypeRequestDto>
    {
        public DocumentTypeValidator()
        {
            RuleFor(x => x.Abbreviation)
                .NotNull().WithMessage("El campo Abreviación no puede ser nulo.")
                .NotEmpty().WithMessage("El campo Abreviación no puede ser vacío.");
        }
    }
}