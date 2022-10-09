using Core.Persistence.Repositories;
using Core.Security.Entities;
using Kodlama.io.Devs.Applicaiton.Abstractions.Repositories;
using Kodlama.io.Devs.Persistence.Contexts;

namespace Kodlama.io.Devs.Persistence.Concrete.Repositories
{
    public class RefreshTokenRepository : EfRepositoryBase<RefreshToken, KodlamaIoDevsContext>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(KodlamaIoDevsContext context) : base(context)
        {
        }
    }
}
