using Core.Application.BusinnesRule;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Applicaiton.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Rules
{
    public class ProgramingLanguageBusinessRules : IGenericBusinessRules<ProgramingLanguage>
    {
        private readonly IProgramingLanguageRepository _programingLanguageRepository;

        public ProgramingLanguageBusinessRules(IProgramingLanguageRepository programingLanguageRepository)
        {
            _programingLanguageRepository = programingLanguageRepository;
        }

        public Task CannotBeNull(ProgramingLanguage item)
        {
            if (item == null) throw new NotFoundException("Requested Programing Language does not exist");
            return Task.CompletedTask;
        }

        public async Task CanNotDuplicate(string name)
        {
            IPaginate<ProgramingLanguage> result = await _programingLanguageRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new DuplicateException("Programing Language name exists.");
        }
    }
}
