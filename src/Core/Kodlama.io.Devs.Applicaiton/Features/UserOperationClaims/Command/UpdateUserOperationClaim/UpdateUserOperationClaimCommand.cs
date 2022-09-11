using AutoMapper;
using Core.Security.Entities;
using Kodlama.io.Devs.Applicaiton.Features.UserOperationClaims.Rules;
using Kodlama.io.Devs.Applicaiton.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.UserOperationClaims.Command.UpdateUserOperationClaim
{
    public class UpdateUserOperationClaimCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid OperationClaimId { get; set; }
        public class UpdateUserOperationClaimCommandHandler : IRequestHandler<UpdateUserOperationClaimCommand, bool>
        {
            private readonly IUserOperationClaimsRepository _userOperationClaimsRepository;
            private readonly UserOperationClaimsBusinessRules _userOperationClaimsBusinessRules;
            private readonly IMapper _mapper;

            public UpdateUserOperationClaimCommandHandler(IUserOperationClaimsRepository userOperationClaimsRepository, UserOperationClaimsBusinessRules userOperationClaimsBusinessRules, IMapper mapper)
            {
                _userOperationClaimsRepository = userOperationClaimsRepository;
                _userOperationClaimsBusinessRules = userOperationClaimsBusinessRules;
                _mapper = mapper;
            }

            public async Task<bool> Handle(UpdateUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                UserOperationClaim? userOperationClaim = await _userOperationClaimsRepository.GetAsync(x => x.Id == request.Id);
                await _userOperationClaimsBusinessRules.CannotBeNull(userOperationClaim);
                await _userOperationClaimsRepository.UpdateAsync(_mapper.Map(request, userOperationClaim));
                return true;
            }
        }
    }
}
