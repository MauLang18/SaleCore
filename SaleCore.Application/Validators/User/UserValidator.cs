using FluentValidation;
using SaleCore.Application.Dtos.User.Request;

namespace SaleCore.Application.Validators.User
{
    public class UserValidator : AbstractValidator<UserRequestDto>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserName)
                .NotNull().WithMessage("El campo Usuario no puede ser nulo.")
                .NotEmpty().WithMessage("El campo Usuario no puede ser vacío.");
        }
    }
}