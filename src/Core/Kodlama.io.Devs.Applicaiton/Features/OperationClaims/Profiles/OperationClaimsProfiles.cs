using AutoMapper;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Applicaiton.Features.OperationClaims.Dtos;
using Kodlama.io.Devs.Applicaiton.Features.Roles.Models;

namespace Kodlama.io.Devs.Applicaiton.Features.OperationClaims.Profiles
{
    public class OperationClaimsProfiles : Profile
    {
        public OperationClaimsProfiles()
        {
            CreateMap<OperationClaim, GetOperationClaimsDto>().ForMember(x => x.ClaimsName, y => y.MapFrom(z => z.Name));
            CreateMap<IPaginate<OperationClaim>, RoleModel>();
        }
    }
}
