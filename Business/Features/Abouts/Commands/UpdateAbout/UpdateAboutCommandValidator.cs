using Business.Features.Abouts.Commands.UpdateAbout;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Abouts.Commands.UpdateAbout
{
    public class UpdateAboutCommandValidator : AbstractValidator<UpdateAboutCommand>
    {
        public UpdateAboutCommandValidator()
        {
            RuleFor(c=>c.Value).NotEmpty().NotNull().WithMessage("Value can not be empty");
            RuleFor(c=>c.Name).NotEmpty().NotNull().WithMessage("Name can not be empty");
            RuleFor(c=>c.Id).NotEmpty().NotNull().WithMessage("Something went wrong");
        }
    }
}
