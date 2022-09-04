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

        internal async Task LanguageCanNotBeDuplicatedWhenInserted(string name)
        {
            var result = await _languageRepository.GetListAsync(b=>b.Name == name);
            if (result.Items.Any()) throw new BusinessException($"Language name({name}) exists.");
        }
    }
}
