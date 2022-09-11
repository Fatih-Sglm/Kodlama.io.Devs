using AutoMapper;
using Core.Security.Entities;
using Kodlama.io.Devs.Applicaiton.Features.UserOperationClaims.Rules;
using Kodlama.io.Devs.Applicaiton.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.UserOperationClaims.Command.CreateUserOperationClaim
{
    public class CreateUserOperationClaimCommand : IRequest<bool>
    {
        public Guid UserId { get; set; }
        public Guid OperationClaimId { get; set; }
    }

    public class CreateUserOperationClaimsCommandHandler : IRequestHandler<CreateUserOperationClaimCommand, bool>
    {
        private readonly IUserOperationClaimsRepository _userOperationClaimsRepository;
        private readonly IMapper _mapper;
        private readonly UserOperationClaimsBusinessRules _userOperationClaimsBusinessRules;

        public CreateUserOperationClaimsCommandHandler(IUserOperationClaimsRepository userOperationClaimsRepository, IMapper mapper, UserOperationClaimsBusinessRules userOperationClaimsBusinessRules)
        {
            _userOperationClaimsRepository = userOperationClaimsRepository;
            _mapper = mapper;
            _userOperationClaimsBusinessRules = userOperationClaimsBusinessRules;
        }

        public async Task<bool> Handle(CreateUserOperationClaimCommand request, CancellationToken cancellationToken)
        {
            await _userOperationClaimsRepository.AddAsync(_mapper.Map<UserOperationClaim>(request));
            return true;
        }
    }
}
