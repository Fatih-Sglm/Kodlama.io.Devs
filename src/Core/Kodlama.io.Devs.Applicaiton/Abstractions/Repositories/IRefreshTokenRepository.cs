using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Kodlama.io.Devs.Applicaiton.Abstractions.Repositories
{
    public interface IRefreshTokenRepository : IAsyncRepository<RefreshToken>
    {
    }
}
