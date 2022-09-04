using AutoMapper;
using Devs.Application.Features.Languages.Dtos;
using Devs.Application.Features.Languages.Rules;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.Languages.Commands.DeleteLanguage
{
    public class DeleteLanguageCommand : IRequest<DeletedLanguageDto>
    {
        public int Id { get; set; }

        public class DeleteLanguageCommandHandler : IRequestHandler<DeleteLanguageCommand, DeletedLanguageDto>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly IMapper _mapper;
            private readonly LanguageBusinessRules _languageBusinessRules;

            public DeleteLanguageCommandHandler(ILanguageRepository languageRepository, IMapper mapper, LanguageBusinessRules languageBusinessRules)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
                _languageBusinessRules = languageBusinessRules;
            }

            public async Task<DeletedLanguageDto> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
            {
                var deletedLanguageRequestEntity = await _languageRepository.GetAsync(item => item.Id == request.Id, enableTracking: false);
                _languageBusinessRules.LanguageShouldExistWhenDeleted(deletedLanguageRequestEntity);

#pragma warning disable CS8604 // Possible null reference argument.
                var deletedEntity = await _languageRepository.DeleteAsync(deletedLanguageRequestEntity);
#pragma warning restore CS8604 // Possible null reference argument.
                var deletedLanguageDto = _mapper.Map<DeletedLanguageDto>(deletedEntity);

                return deletedLanguageDto;
            }
        }
    }
}
