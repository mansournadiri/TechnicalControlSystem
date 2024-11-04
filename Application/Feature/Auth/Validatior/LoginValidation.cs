using Application.Feature.Auth.Request.Command;
using FluentValidation;

namespace Application.Feature.Auth.Validatior
{
    public class LoginValidation : AbstractValidator<LoginViewModel>
    {
        public LoginValidation()
        {
            RuleFor(command => command.email)
                .NotNull().WithMessage("EmailNotNull")
                .NotEmpty().WithMessage("EmailNotEmpty")
                .EmailAddress().WithMessage("InvalidEmail")
                .MaximumLength(255).WithMessage("EmailMaxLength");

            RuleFor(command => command.password)
                .NotNull().WithMessage("PasswordNotNull")
                .NotEmpty().WithMessage("PasswordNotEmpty")
                .MinimumLength(3).WithMessage("PasswordMinLength")
                .Matches(@"^[^\s]+$").WithMessage("PasswordNoSpaces")
                .MaximumLength(50).WithMessage("PasswordMaxLength");
        }
    }
}
