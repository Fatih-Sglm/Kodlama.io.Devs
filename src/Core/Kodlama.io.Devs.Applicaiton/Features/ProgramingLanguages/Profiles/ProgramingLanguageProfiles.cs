using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Command.CreateCommand;
using Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Command.UpdateCommand;
using Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Dtos;
using Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Models;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Profiles
{
    public class ProgramingLanguageProfiles : Profile
    {
        public ProgramingLanguageProfiles()
        {
            CreateMap<CreateProgramingLanguageCommand, ProgramingLanguage>();
            CreateMap<IPaginate<ProgramingLanguage>, PLListModel>();
            CreateMap<ProgramingLanguage, PLLDto>();
            CreateMap<UpdateProgramingLanguageCommand, ProgramingLanguage>();
        }
    }
}
