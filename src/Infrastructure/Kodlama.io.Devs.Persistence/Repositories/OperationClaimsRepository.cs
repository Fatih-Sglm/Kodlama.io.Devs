using Core.Persistence.Repositories;
using Core.Security.Entities;
using Kodlama.io.Devs.Applicaiton.Services.Repositories;
using Kodlama.io.Devs.Persistence.Contexts;

namespace Kodlama.io.Devs.Persistence.Repositories
{
    public class OperationClaimsRepository : EfRepositoryBase<OperationClaim, KodlamaIoDevsContext>, IOperationClaimsRepository
    {
        public OperationClaimsRepository(KodlamaIoDevsContext context) : base(context)
        {
        }
    }
}
