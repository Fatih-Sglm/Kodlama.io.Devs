using AutoMapper;
using Core.Security.Entities;
using Kodlama.io.Devs.Applicaiton.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.OperationClaims.Command.CreateOperationClaim
{
    public class CreateOperationClaimCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public class CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommand, bool>
        {
            private readonly IOperationClaimsRepository _operationClaimsRepository;
            private readonly IMapper _mapper;


            public CreateOperationClaimCommandHandler(IOperationClaimsRepository operationClaimsRepository, IMapper mapper)
            {
                _operationClaimsRepository = operationClaimsRepository;
                _mapper = mapper;
            }

            public async Task<bool> Handle(CreateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                await _operationClaimsRepository.AddAsync(_mapper.Map<OperationClaim>(request));
                return true;
            }
        }
    }
}
