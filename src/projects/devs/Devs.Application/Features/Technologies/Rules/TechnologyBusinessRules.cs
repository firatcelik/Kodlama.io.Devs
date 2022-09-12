using Core.CrossCuttingConcerns.Exceptions;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.Technologies.Rules
{
    public class TechnologyBusinessRules
    {
        private readonly ITechnologyRepository _technologyeRepository;

        public TechnologyBusinessRules(ITechnologyRepository tehnologyeRepository)
        {
            _technologyeRepository = tehnologyeRepository;
        }

        internal async Task TechnologyCanNotBeDuplicatedWhenInsertedOrUpdated(string name)
        {
            var result = await _technologyeRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException($"Technolgy name({name}) exists.");
        }

        internal void TechnologyShouldExistWhenRequested(Technology? technology)
        {
            if (technology == null) throw new BusinessException("Requested technology does not exist");
        }
    }
}