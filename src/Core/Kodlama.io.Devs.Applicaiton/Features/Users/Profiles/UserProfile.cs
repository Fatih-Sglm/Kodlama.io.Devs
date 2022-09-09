using AutoMapper;
using Kodlama.io.Devs.Applicaiton.Features.Users.Command.CreateUser;
using Kodlama.io.Devs.Applicaiton.Features.Users.Command.UpdateUser;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Applicaiton.Features.Users.Profiles
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
