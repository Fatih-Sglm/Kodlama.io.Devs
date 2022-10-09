using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Kodlama.io.Devs.Applicaiton.Abstractions.Repositories
{
    public interface IUserRepository : IAsyncRepository<User>
    {
    }
}
