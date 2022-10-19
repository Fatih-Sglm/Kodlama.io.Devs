using Core.Domain.Entities;

namespace Kodlama.io.Devs.Applicaiton.Abstractions.Services
{
    public interface IOperationClaimsService
    {
        Task<IQueryable<OperationClaim>> GetOperationClaims();
    }
}
