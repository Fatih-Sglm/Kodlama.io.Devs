using Core.Persistence.Repositories;
using Kodlama.io.Devs.Applicaiton.Abstractions.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using Kodlama.io.Devs.Persistence.Contexts;

namespace Kodlama.io.Devs.Persistence.Concrete.Repositories
{
    public class AppUserRepository : EfRepositoryBase<AppUser, KodlamaIoDevsContext>, IAppUserRepository
    {
        public AppUserRepository(KodlamaIoDevsContext context) : base(context)
        {
        }
    }
}
