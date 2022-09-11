using Core.Security.Entities;
using Kodlama.io.Devs.Applicaiton.Features.OperationClaims.Rules;
using Kodlama.io.Devs.Applicaiton.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.OperationClaims.Command.DeleteOperationClaim
{
    public class DeleteOperationClaimCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public class DeleteOperationClaimsCommandHandler : IRequestHandler<DeleteOperationClaimCommand, bool>
        {
            private readonly IOperationClaimsRepository _operationClaimsRepository;
            private readonly OperationClaimBusineesRules _operationClaimBusineesRules;

            public DeleteOperationClaimsCommandHandler(IOperationClaimsRepository operationClaimsRepository, OperationClaimBusineesRules operationClaimBusineesRules)
            {
                _operationClaimsRepository = operationClaimsRepository;
                _operationClaimBusineesRules = operationClaimBusineesRules;
            }

            public async Task<bool> Handle(DeleteOperationClaimCommand request, CancellationToken cancellationToken)
            {
                OperationClaim? operationClaim = await _operationClaimsRepository.GetAsync(x => x.Id == request.Id);
                await _operationClaimBusineesRules.CannotBeNull(operationClaim);
                await _operationClaimsRepository.DeleteAsync(operationClaim);
                return true;
            }
        }
    }
}
