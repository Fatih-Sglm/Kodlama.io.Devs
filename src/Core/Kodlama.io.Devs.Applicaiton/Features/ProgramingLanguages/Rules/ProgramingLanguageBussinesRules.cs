using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Applicaiton.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Rules
{
    public class ProgramingLanguageBussinesRules
    {
        private readonly IProgramingLanguageRepository _programingLanguageRepository;

        public ProgramingLanguageBussinesRules(IProgramingLanguageRepository programingLanguageRepository)
        {
            _programingLanguageRepository = programingLanguageRepository;
        }

        public async Task ProgramingLanguageCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgramingLanguage> result = await _programingLanguageRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new DuplicateException("Programing Language name exists.");
        }

        public void ProgramingLanguageShouldExist(ProgramingLanguage pl)
        {
            if (pl == null) throw new NotFoundException("Requested Programing Language does not exist");
        }
    }
}
