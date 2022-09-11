using AutoMapper;
using Core.Security.Entities;
using Kodlama.io.Devs.Applicaiton.Features.OperationClaims.Command.CreateOperationClaim;
using Kodlama.io.Devs.Applicaiton.Features.OperationClaims.Command.UpdateOperationClaim;

namespace Kodlama.io.Devs.Applicaiton.Features.OperationClaims.Profiles
{
    public class OperationClaimsProfiles : Profile
    {
        public OperationClaimsProfiles()
        {
            CreateMap<CreateOperationClaimCommand, OperationClaim>();
            CreateMap<UpdateOperationClaimCommand, OperationClaim>();
        }
    }
}
