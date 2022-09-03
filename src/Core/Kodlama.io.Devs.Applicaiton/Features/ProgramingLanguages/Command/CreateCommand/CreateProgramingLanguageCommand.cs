using AutoMapper;
using Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Rules;
using Kodlama.io.Devs.Applicaiton.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Command.CreateCommand
{
    public class CreateProgramingLanguageCommand : IRequest<bool>
    {
        public string Name { get; set; }

        public class CreateProgramingLanguageCommandHandler : IRequestHandler<CreateProgramingLanguageCommand, bool>
        {
            private readonly IProgramingLanguageRepository _programingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgramingLanguageBussinesRules _programingLanguageBussinesRules;

            public CreateProgramingLanguageCommandHandler(IProgramingLanguageRepository programingLanguageRepository, IMapper mapper, ProgramingLanguageBussinesRules programingLanguageBussinesRules)
            {
                _programingLanguageRepository = programingLanguageRepository;
                _mapper = mapper;
                _programingLanguageBussinesRules = programingLanguageBussinesRules;
            }

            public async Task<bool> Handle(CreateProgramingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _programingLanguageBussinesRules.ProgramingLanguageCanNotBeDuplicatedWhenInserted(request.Name);
                await _programingLanguageRepository.AddAsync(_mapper.Map<ProgramingLanguage>(request));
                return true;
            }
        }
    }
}
