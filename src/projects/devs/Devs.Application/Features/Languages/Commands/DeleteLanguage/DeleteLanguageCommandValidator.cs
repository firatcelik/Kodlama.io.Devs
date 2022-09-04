using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.Languages.Commands.DeleteLanguage
{
    public class DeleteLanguageCommandValidator:AbstractValidator<DeleteLanguageCommand>
    {
        public DeleteLanguageCommandValidator()
        {
            RuleFor(u => u.Id).NotNull().NotEmpty();
        }
    }
}
