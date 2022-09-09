using Core.Persistence.Repositories;
using Kodlama.io.Devs.Applicaiton.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using Kodlama.io.Devs.Persistence.Contexts;

namespace Kodlama.io.Devs.Persistence.Repositories
{
    public class ProfileLinksRepository : EfRepositoryBase<ProfileLink, KodlamaIoDevsContext>, IProfileLinksRepository
    {
        public ProfileLinksRepository(KodlamaIoDevsContext context) : base(context)
        {
        }
    }
}
