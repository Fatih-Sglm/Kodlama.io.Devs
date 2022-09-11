using Core.Persistence.Repositories;
using Kodlama.io.Devs.Applicaiton.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using Kodlama.io.Devs.Persistence.Contexts;

namespace Kodlama.io.Devs.Persistence.Repositories
{
    public class ProfileTypeRepository : EfRepositoryBase<ProfileType, KodlamaIoDevsContext>, IProfileTypeRepository
    {
        public ProfileTypeRepository(KodlamaIoDevsContext context) : base(context)
        {
        }
    }
}
