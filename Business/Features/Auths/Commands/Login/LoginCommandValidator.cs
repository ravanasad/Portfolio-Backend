using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Auths.Commands.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage("Email can not be empty");
            RuleFor(x => x.Password).NotEmpty().NotNull().WithMessage("Password can not be empty");
        }
    }
}
