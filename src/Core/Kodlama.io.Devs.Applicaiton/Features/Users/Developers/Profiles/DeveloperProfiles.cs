using AutoMapper;
using Kodlama.io.Devs.Applicaiton.Features.Auths.Command.DeveloperCommand.RegisterDeveloper;
using Kodlama.io.Devs.Applicaiton.Features.Users.Developers.Command.UpdateDeveloper;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Applicaiton.Features.Users.Developers.Profiles
{
    public class DeveloperProfiles : Profile
    {
        public DeveloperProfiles()
        {
            CreateMap<RegisterDeveloperCommand, Developer>();
            CreateMap<UpdateDeveloperCommand, Developer>();
        }
    }
}
