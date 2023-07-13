using FluentValidation;

namespace Business.Features.Auths.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(c=>c.Email).NotEmpty().NotNull().WithMessage("Email can not be empty");
            RuleFor(c=>c.Password).NotEmpty().NotNull().WithMessage("Password can not be empty").Equal(c=>c.PasswordConfirm).WithMessage("Password doesnt match with passwordconfirm");
            RuleFor(c=>c.PasswordConfirm).NotEmpty().NotNull().WithMessage("PasswordConfirm can not be empty");
        }
    }
}
