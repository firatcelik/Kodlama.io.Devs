using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Devs.Application.Features.Languages.Commands.CreateLanguage;
using Devs.Application.Features.Languages.Commands.DeleteLanguage;
using Devs.Application.Features.Languages.Commands.UpdateLanguage;
using Devs.Application.Features.Languages.Dtos;
using Devs.Application.Features.Languages.Models;
using Devs.Application.Features.Languages.Queries.GetListLanguage;
using Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.Languages.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Language, CreatedLanguageDto>().ReverseMap();
            CreateMap<Language, CreateLanguageCommand>().ReverseMap();

            CreateMap<Language, LanguageListDto>().ReverseMap();
            CreateMap<IPaginate<Language>, LanguageListModel>().ReverseMap();

            CreateMap<Language, LanguageGetByIdDto>().ReverseMap();

            CreateMap<Language, UpdateLanguageCommand>().ReverseMap();
            CreateMap<Language, UpdatedLanguageDto>().ReverseMap();

            CreateMap<Language, DeletedLanguageDto>().ReverseMap();
            CreateMap<Language, DeleteLanguageCommand>().ReverseMap();
        }
    }
}
