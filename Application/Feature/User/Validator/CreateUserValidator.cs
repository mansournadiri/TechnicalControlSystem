using Application.Feature.User.Request.Command;
using FluentValidation;

namespace Application.Feature.User.Validator
{
    public class CreateUserValidator : AbstractValidator<CreateUserViewModel>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Password)
                .NotNull().WithMessage("PasswordNotNull")
                .NotEmpty().WithMessage("PasswordNotEmpty")
                .MinimumLength(3).WithMessage("PasswordMinLength")
                .Matches(@"^[^\s]+$").WithMessage("PasswordNoSpaces")
                .MaximumLength(50).WithMessage("PasswordMaxLength");
        }
    }
}
