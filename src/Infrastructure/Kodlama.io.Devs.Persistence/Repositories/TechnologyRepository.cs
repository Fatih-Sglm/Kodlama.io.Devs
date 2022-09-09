using Core.Persistence.Repositories;
using Kodlama.io.Devs.Applicaiton.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using Kodlama.io.Devs.Persistence.Contexts;

namespace Kodlama.io.Devs.Persistence.Repositories
{
    public class TechnologyRepository : EfRepositoryBase<Technology, KodlamaIoDevsContext>, ITechnologyRepository
    {
        public TechnologyRepository(KodlamaIoDevsContext context) : base(context)
        {
        }
    }
}
