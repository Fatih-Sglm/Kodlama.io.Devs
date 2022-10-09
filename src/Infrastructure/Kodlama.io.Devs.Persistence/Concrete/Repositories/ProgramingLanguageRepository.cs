using Core.Persistence.Repositories;
using Kodlama.io.Devs.Applicaiton.Abstractions.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using Kodlama.io.Devs.Persistence.Contexts;

namespace Kodlama.io.Devs.Persistence.Concrete.Repositories
{
    public class ProgramingLanguageRepository : EfRepositoryBase<ProgramingLanguage, KodlamaIoDevsContext>, IProgramingLanguageRepository
    {
        public ProgramingLanguageRepository(KodlamaIoDevsContext context) : base(context)
        {
        }
    }
}
