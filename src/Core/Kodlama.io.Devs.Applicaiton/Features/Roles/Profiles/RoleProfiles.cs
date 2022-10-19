using AutoMapper;
using Core.Domain.Entities;
using Kodlama.io.Devs.Applicaiton.Features.Roles.Command.CreateRole;

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
