using AutoMapper;
using Devs.Application.Features.Technologies.Dtos;
using Devs.Application.Features.Technologies.Rules;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;

namespace Devs.Application.Features.Technologies.Commands.CreateLanguage
{
    public class CreateTechnologyCommand : IRequest<CreatedTechnologyDto>
    {
        public string Name { get; set; }

        public int LanguageId { get; set; }

        public class CreateTechnologyCommandHandler : IRequestHandler<CreateTechnologyCommand, CreatedTechnologyDto>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;
            private readonly TechnologyBusinessRules _technologyBusinessRules;

            public CreateTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
                _technologyBusinessRules = technologyBusinessRules;
            }

            public async Task<CreatedTechnologyDto> Handle(CreateTechnologyCommand request, CancellationToken cancellationToken)
            {
                //TODO : check only one technology can add to table
                await _technologyBusinessRules.TechnologyCanNotBeDuplicatedWhenInsertedOrUpdated(request.Name);

                var mappedTechnology = _mapper.Map<Technology>(request);
                var createdTechnogy= await _technologyRepository.AddAsync(mappedTechnology);
                var createdTechnologyDto = _mapper.Map<CreatedTechnologyDto>(createdTechnogy);
                return createdTechnologyDto;
            }
        }
    }
}
