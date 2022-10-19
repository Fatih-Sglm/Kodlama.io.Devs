using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Kodlama.io.Devs.Applicaiton.Abstractions.Repositories
{
    public interface IUserRepository : IAsyncRepository<User>
    {
    }
}
