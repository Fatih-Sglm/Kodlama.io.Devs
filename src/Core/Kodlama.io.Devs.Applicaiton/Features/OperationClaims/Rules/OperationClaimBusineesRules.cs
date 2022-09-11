using Core.Application.BusinnesRule;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Kodlama.io.Devs.Applicaiton.Services.Repositories;

namespace Kodlama.io.Devs.Applicaiton.Features.OperationClaims.Rules
{
    public class OperationClaimBusineesRules : IGenericBusinessRules<OperationClaim>
    {
        private readonly IOperationClaimsRepository _operationClaimsRepository;

        public OperationClaimBusineesRules(IOperationClaimsRepository operationClaimsRepository)
        {
            _operationClaimsRepository = operationClaimsRepository;
        }

        public Task CannotBeNull(OperationClaim item)
        {
            if (item == null) throw new NotFoundException("");
            return Task.CompletedTask;
        }

        public async Task CanNotDuplicate(string name)
        {
            IPaginate<OperationClaim> items = await _operationClaimsRepository.GetListAsync();
            if (items.Items.Any()) throw new DuplicateException("");
        }
    }
}
