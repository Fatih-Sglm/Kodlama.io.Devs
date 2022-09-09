using Core.Persistence.Repositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Applicaiton.Services.Repositories
{
    public interface IAuthRepository : IAsyncRepository<AppUser>
    {
    }
}
