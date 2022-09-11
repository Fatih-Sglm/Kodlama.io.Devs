using Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Rules;
using Kodlama.io.Devs.Applicaiton.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Command.DeleteCommand
{
    public class DeleteProgramingLanguageCommand : IRequest<bool>
    {
        public string Id { get; set; }
    }
    public class DeleteProgramingLanguageCommandHandler : IRequestHandler<DeleteProgramingLanguageCommand, bool>
    {
        private readonly IProgramingLanguageRepository _programingLanguageRepository;
        private readonly ProgramingLanguageBussinesRules _programingLanguageBussinesRules;

        public DeleteProgramingLanguageCommandHandler(IProgramingLanguageRepository programingLanguageRepository, ProgramingLanguageBussinesRules programingLanguageBussinesRules)
        {
            _programingLanguageRepository = programingLanguageRepository;
            _programingLanguageBussinesRules = programingLanguageBussinesRules;
        }

        public async Task<bool> Handle(DeleteProgramingLanguageCommand request, CancellationToken cancellationToken)
        {
            ProgramingLanguage? programingLanguage = await _programingLanguageRepository.GetAsync(x => x.Id == Guid.Parse(request.Id));
            await _programingLanguageBussinesRules.CannotBeNull(programingLanguage);
            await _programingLanguageRepository.DeleteAsync(programingLanguage);
            return true;
        }
    }
}
