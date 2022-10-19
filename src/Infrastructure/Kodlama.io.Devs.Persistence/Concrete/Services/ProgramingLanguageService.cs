using Kodlama.io.Devs.Applicaiton.Abstractions.Repositories;
using Kodlama.io.Devs.Applicaiton.Abstractions.Services;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Persistence.Concrete.Services
{
    public class ProgramingLanguageService : IProgramingLanguageService
    {
        private readonly IProgramingLanguageRepository _programingLanguageRepository;

        public ProgramingLanguageService(IProgramingLanguageRepository programingLanguageRepository)
        {
            _programingLanguageRepository = programingLanguageRepository;
        }

        public async Task<ProgramingLanguage> GetById(Guid id)
        {
            ProgramingLanguage pl = await _programingLanguageRepository.GetAsync(x => x.Id == id);
            return pl;
        }
    }
}
