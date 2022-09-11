using Core.Persistence.Repositories;
using Kodlama.io.Devs.Applicaiton.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using Kodlama.io.Devs.Persistence.Contexts;

namespace Kodlama.io.Devs.Persistence.Repositories
{
    public class AppUserRepository : EfRepositoryBase<AppUser, KodlamaIoDevsContext>, IAppUserRepository
    {
        public AppUserRepository(KodlamaIoDevsContext context) : base(context)
        {
        }
    }
}
