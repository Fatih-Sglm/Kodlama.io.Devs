using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Kodlama.io.Devs.Applicaiton.Services.Repositories
{
    public interface IUserOperationClaimsRepository : IAsyncRepository<UserOperationClaim>
    {
    }
}
