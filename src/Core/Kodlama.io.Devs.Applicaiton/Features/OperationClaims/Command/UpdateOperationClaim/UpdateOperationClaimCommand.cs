using AutoMapper;
using Core.Security.Entities;
using Kodlama.io.Devs.Applicaiton.Features.OperationClaims.Rules;
using Kodlama.io.Devs.Applicaiton.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.OperationClaims.Command.UpdateOperationClaim
{
    public class UpdateOperationClaimCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public class UpdateOperationClaimsCommandHandler : IRequestHandler<UpdateOperationClaimCommand, bool>
        {
            private readonly IOperationClaimsRepository _operationClaimsRepository;
            private readonly IMapper _mapper;
            private readonly OperationClaimBusineesRules _operationClaimBusineesRules;

            public UpdateOperationClaimsCommandHandler(IOperationClaimsRepository operationClaimsRepository, IMapper mapper, OperationClaimBusineesRules operationClaimBusineesRules)
            {
                _operationClaimsRepository = operationClaimsRepository;
                _mapper = mapper;
                _operationClaimBusineesRules = operationClaimBusineesRules;
            }

            public async Task<bool> Handle(UpdateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                OperationClaim? operationClaim = await _operationClaimsRepository.GetAsync(x => x.Id == request.Id);
                await _operationClaimBusineesRules.CannotBeNull(operationClaim);
                await _operationClaimsRepository.UpdateAsync(_mapper.Map(request, operationClaim));
                return true;
            }
        }
    }
}
