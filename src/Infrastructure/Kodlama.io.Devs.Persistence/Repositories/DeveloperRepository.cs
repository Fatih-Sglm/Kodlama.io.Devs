using Core.Persistence.Repositories;
using Kodlama.io.Devs.Applicaiton.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using Kodlama.io.Devs.Persistence.Contexts;

namespace Kodlama.io.Devs.Persistence.Repositories
{
    public class DeveloperRepository : EfRepositoryBase<Developer, KodlamaIoDevsContext>, IDeveloperRepository
    {
        public DeveloperRepository(KodlamaIoDevsContext context) : base(context)
        {
        }
    }
}
