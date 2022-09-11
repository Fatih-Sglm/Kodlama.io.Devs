using AutoMapper;
using Core.Security.Entities;
using Kodlama.io.Devs.Applicaiton.Features.UserOperationClaims.Command.CreateUserOperationClaim;

namespace Kodlama.io.Devs.Applicaiton.Features.UserOperationClaims.Profiles
{
    public class UserOperationClaimsProfile : Profile
    {
        public UserOperationClaimsProfile()
        {
            CreateMap<CreateUserOperationClaimCommand, UserOperationClaim>();
        }
    }
}
