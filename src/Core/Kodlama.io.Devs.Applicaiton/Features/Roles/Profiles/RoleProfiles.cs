using AutoMapper;
using Core.Security.Entities;
using Kodlama.io.Devs.Applicaiton.Features.Roles.Command.CreateRoleClaim;

namespace Kodlama.io.Devs.Applicaiton.Features.Roles.Profiles
{
    public class RoleProfiles : Profile
    {
        public RoleProfiles()
        {
            CreateMap<CreateRoleCommand, Role>();

        }
    }
}
