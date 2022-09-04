using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.Languages.Rules
{
    public class LanguageBusinessRules
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguageBusinessRules(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        internal async Task LanguageCanNotBeDuplicatedWhenInsertedOrUpdated(string name)
        {
            var result = await _languageRepository.GetListAsync(b=>b.Name == name);
            if (result.Items.Any()) throw new BusinessException($"Language name({name}) exists.");
        }

        internal void LanguageShouldExistWhenRequested(Language? language)
        {
            if (language == null) throw new BusinessException("Requested language does not exist");
        }

        internal void LanguageShouldExistWhenDeleted(Language? deletedLanguageEntity)
        {
            if (deletedLanguageEntity == null) throw new BusinessException("There is no programming language to delete");
        }

        internal async Task LanguageShouldExistWhenDeleted(int id)
        {
            var deletedLanguageEntity = await _languageRepository.GetAsync(item => item.Id == id);
            if (deletedLanguageEntity == null) throw new BusinessException("There is no programming language to delete");
        }
    }
}
