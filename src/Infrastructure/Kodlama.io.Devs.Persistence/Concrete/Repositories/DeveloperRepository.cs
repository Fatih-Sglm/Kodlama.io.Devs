using Core.Persistence.Repositories;
using Kodlama.io.Devs.Applicaiton.Abstractions.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using Kodlama.io.Devs.Persistence.Contexts;

namespace Kodlama.io.Devs.Persistence.Concrete.Repositories
{
    public class DeveloperRepository : EfRepositoryBase<Developer, KodlamaIoDevsContext>, IDeveloperRepository
    {
        public DeveloperRepository(KodlamaIoDevsContext context) : base(context)
        {
        }
    }
}
