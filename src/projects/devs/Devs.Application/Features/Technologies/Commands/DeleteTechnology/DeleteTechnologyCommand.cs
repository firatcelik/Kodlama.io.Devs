using AutoMapper;
using Devs.Application.Features.Technologies.Dtos;
using Devs.Application.Features.Technologies.Rules;
using Devs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.Technologies.Commands.DeleteTechnology
{
    public class DeleteTechnologyCommand : IRequest<DeletedTechnologyDto>
    {
        public int Id { get; set; }
        public class DeleteTechnologyCommandHandler : IRequestHandler<DeleteTechnologyCommand, DeletedTechnologyDto>
        {

            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;
            private readonly TechnologyBusinessRules _technologyBusinessRules;

            public DeleteTechnologyCommandHandler(ITechnologyRepository technologyRepository,
                IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
                _technologyBusinessRules = technologyBusinessRules;
            }

            public async Task<DeletedTechnologyDto> Handle(DeleteTechnologyCommand request, CancellationToken cancellationToken)
            {
                var deletedTechnologyRequestEntity = await _technologyRepository.GetAsync(item => item.Id == request.Id, enableTracking: false);
                _technologyBusinessRules.TechnologyShouldExistWhenDeleted(deletedTechnologyRequestEntity);

#pragma warning disable CS8604 // Possible null reference argument.
                var deletedEntity = await _technologyRepository.DeleteAsync(deletedTechnologyRequestEntity);
#pragma warning restore CS8604 // Possible null reference argument.
                var deletedTechnologyDto = _mapper.Map<DeletedTechnologyDto>(deletedEntity);

                return deletedTechnologyDto;
            }
        }
    }
}
