using AutoMapper;
using Kodlama.io.Devs.Applicaiton.Features.AppUsers.Command.CreateUser;
using Kodlama.io.Devs.Applicaiton.Features.AppUsers.Command.UpdateUser;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Applicaiton.Features.AppUsers.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserCommand, AppUser>();
            CreateMap<UpdateUserCommand, AppUser>();

        }
    }
}
