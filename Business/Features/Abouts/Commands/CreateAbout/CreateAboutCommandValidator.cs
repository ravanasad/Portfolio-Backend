using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Abouts.Commands.CreateAbout
{
    public class DeleteAboutCommandValidator : AbstractValidator<CreateAboutCommand>
    {
        public DeleteAboutCommandValidator()
        {
            RuleFor(c=>c.Value).NotEmpty().NotNull().WithMessage("Value can not be empty");
            RuleFor(c=>c.Name).NotEmpty().NotNull().WithMessage("Name can not be empty");
        }
    }
}
