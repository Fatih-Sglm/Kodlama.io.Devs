using Core.Persistence.Repositories;
using Core.Security.Entities;
using Kodlama.io.Devs.Applicaiton.Services.Repositories;
using Kodlama.io.Devs.Persistence.Contexts;

namespace Kodlama.io.Devs.Persistence.Repositories
{
    public class UserOperationClaimsRepository : EfRepositoryBase<UserOperationClaim, KodlamaIoDevsContext>, IUserOperationClaimsRepository
    {
        public UserOperationClaimsRepository(KodlamaIoDevsContext context) : base(context)
        {
        }
    }
}
