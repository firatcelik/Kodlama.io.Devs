using Devs.Application.Features.Technologies.Commands.CreateTechnology;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.Technologies.Commands.CreateTechnogy
{
    internal class CreateTechnologyCommandValidator : AbstractValidator<CreateTechnologyCommand>
    {
        public CreateTechnologyCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Name).MinimumLength(1);
            RuleFor(c => c.Name).NotNull();
            RuleFor(c=>c.LanguageId).NotEmpty()
               .NotNull()
               .GreaterThanOrEqualTo(0);
        }
    }
}
