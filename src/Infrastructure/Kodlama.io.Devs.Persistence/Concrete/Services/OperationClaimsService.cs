using Core.Domain.Entities;
using Kodlama.io.Devs.Applicaiton.Abstractions.Repositories;
using Kodlama.io.Devs.Applicaiton.Abstractions.Services;

namespace Kodlama.io.Devs.Persistence.Concrete.Services
{
    public class OperationClaimsService : IOperationClaimsService
    {
        private readonly IOperationClaimsRepository _operationClaimsRepository;

        public OperationClaimsService(IOperationClaimsRepository operationClaimsRepository)
        {
            _operationClaimsRepository = operationClaimsRepository;
        }

        public async Task<IQueryable<OperationClaim>> GetOperationClaims()
        {
            return await _operationClaimsRepository.GetAllIQueryableAsync();
        }
    }
}
