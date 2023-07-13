using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Abouts.Commands.DeleteAbout
{
    public class DeleteAboutCommandValidator : AbstractValidator<DeleteAboutCommand>
    {
        public DeleteAboutCommandValidator()
        {
            RuleFor(c=>c.Id).NotEmpty().NotNull().WithMessage("Something went wrong");
        }
    }
}
