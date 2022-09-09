using Core.Persistence.Repositories;
using Kodlama.io.Devs.Applicaiton.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using Kodlama.io.Devs.Persistence.Contexts;

namespace Kodlama.io.Devs.Persistence.Repositories
{
    public class AuthRepository : EfRepositoryBase<AppUser, KodlamaIoDevsContext>, IAuthRepository
    {
        public AuthRepository(KodlamaIoDevsContext context) : base(context)
        {
        }
    }
}
