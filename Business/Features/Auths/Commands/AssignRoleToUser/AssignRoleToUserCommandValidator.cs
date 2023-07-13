using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Auths.Commands.AssignRoleToUser
{
    public class AssignRoleToUserCommandValidator : AbstractValidator<AssignRoleToUserCommand>
    {
        public AssignRoleToUserCommandValidator()
        {
            RuleFor(c=>c.Id).NotEmpty().NotNull().WithMessage("Something went wrong");
            RuleFor(c=>c.Roles).NotEmpty().NotNull().WithMessage("Roles can not be emtpy");
        }
    }
}
