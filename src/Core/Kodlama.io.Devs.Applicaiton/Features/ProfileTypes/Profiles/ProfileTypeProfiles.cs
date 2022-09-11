using AutoMapper;
using Kodlama.io.Devs.Applicaiton.Features.ProfileTypes.Command.CreateProfileType;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Applicaiton.Features.ProfileTypes.Profiles
{
    public class ProfileTypeProfiles : Profile
    {
        public ProfileTypeProfiles()
        {
            CreateMap<CreateProfileTypeCommand, ProfileType>();
        }
    }
}
