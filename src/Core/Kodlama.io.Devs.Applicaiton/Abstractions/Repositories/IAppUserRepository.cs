using Core.Persistence.Repositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Applicaiton.Abstractions.Repositories
{
    public interface IAppUserRepository : IAsyncRepository<AppUser>
    {
    }
}
