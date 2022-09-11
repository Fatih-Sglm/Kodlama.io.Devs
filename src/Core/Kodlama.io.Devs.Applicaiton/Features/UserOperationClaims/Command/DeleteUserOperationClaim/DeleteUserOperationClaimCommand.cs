using Core.Security.Entities;
using Kodlama.io.Devs.Applicaiton.Features.UserOperationClaims.Rules;
using Kodlama.io.Devs.Applicaiton.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.UserOperationClaims.Command.DeleteUserOperationClaim
{
    public class DeleteUserOperationClaimCommand : IRequest<bool>
    {
        public Guid Id { get; set; }


        public class DeleteUserOperationClaimCommandHandler : IRequestHandler<DeleteUserOperationClaimCommand, bool>
        {
            private readonly IUserOperationClaimsRepository _userOperationClaimsRepository;
            private readonly UserOperationClaimsBusinessRules _userOperationClaimsBusinessRules;

            public DeleteUserOperationClaimCommandHandler(IUserOperationClaimsRepository userOperationClaimsRepository, UserOperationClaimsBusinessRules userOperationClaimsBusinessRules)
            {
                _userOperationClaimsRepository = userOperationClaimsRepository;
                _userOperationClaimsBusinessRules = userOperationClaimsBusinessRules;
            }

            public async Task<bool> Handle(DeleteUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                UserOperationClaim? userOperationClaim = await _userOperationClaimsRepository.GetAsync(x => x.Id == request.Id);
                await _userOperationClaimsBusinessRules.CannotBeNull(userOperationClaim);
                return true;
            }
        }
    }
}
