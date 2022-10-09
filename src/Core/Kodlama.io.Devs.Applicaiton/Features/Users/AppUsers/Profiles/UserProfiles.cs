using AutoMapper;
using Kodlama.io.Devs.Applicaiton.Features.Auths.Command.AppUsersCommand.RegisterAppUser;
using Kodlama.io.Devs.Applicaiton.Features.Users.AppUsers.Command.UpdateUser;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Applicaiton.Features.Users.AppUsers.Profiles
{
    public class UserProfiles : Profile
    {
        public UserProfiles()
        {
            CreateMap<RegisterAppUserCommand, AppUser>();
            CreateMap<UpdateUserCommand, AppUser>();

        }
    }
}
