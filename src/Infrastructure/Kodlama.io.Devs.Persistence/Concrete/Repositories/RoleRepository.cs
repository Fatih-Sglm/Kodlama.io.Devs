using Core.Domain.Entities;
using Core.Persistence.Repositories;
using Kodlama.io.Devs.Applicaiton.Abstractions.Repositories;
using Kodlama.io.Devs.Persistence.Contexts;

namespace Kodlama.io.Devs.Persistence.Concrete.Repositories
{
    public class RoleRepository : EfRepositoryBase<Role, KodlamaIoDevsContext>, IRoleRepository
    {
        public RoleRepository(KodlamaIoDevsContext context) : base(context)
        {
        }
    }
}
