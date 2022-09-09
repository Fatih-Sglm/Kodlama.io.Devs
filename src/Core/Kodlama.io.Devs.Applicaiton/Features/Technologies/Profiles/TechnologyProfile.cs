using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Applicaiton.Features.Technologies.Command;
using Kodlama.io.Devs.Applicaiton.Features.Technologies.Dtos;
using Kodlama.io.Devs.Applicaiton.Features.Technologies.Models;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Applicaiton.Features.Technologies.Profiles
{
    public class TechnologyProfile : Profile
    {
        public TechnologyProfile()
        {
            CreateMap<IPaginate<Technology>, TechnologyListModel>();
            CreateMap<Technology, GetTechnologyDto>().ForMember(x => x.ProgramingLanguageName, opt => opt.MapFrom(x => x.ProgramingLanguage.Name));
            CreateMap<UpdateTechnologyCommand, Technology>();
            CreateMap<CreateTechnologyCommand, Technology>();
        }
    }
}
