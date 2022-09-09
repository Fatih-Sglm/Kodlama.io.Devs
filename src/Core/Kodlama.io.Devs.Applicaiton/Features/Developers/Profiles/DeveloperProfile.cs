using AutoMapper;
using Kodlama.io.Devs.Applicaiton.Features.Developers.Command.CreateDeveloper;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Applicaiton.Features.Developers.Profiles
{
    public class DeveloperProfile : Profile
    {
        public DeveloperProfile()
        {
            CreateMap<CreateDeveloperCommand, AppUser>();
        }
    }
}
