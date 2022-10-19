using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Kodlama.io.Devs.Applicaiton.Abstractions.Repositories;
using Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Rules;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Command.CreateCommand
{
    public class CreateProgramingLanguageCommand : IRequest<bool>, ISecuredRequest
    {
        public string Name { get; set; }

        public string[] Roles => new[] { nameof(CreateProgramingLanguageCommand) };

        public class CreateProgramingLanguageCommandHandler : IRequestHandler<CreateProgramingLanguageCommand, bool>
        {
            private readonly IProgramingLanguageRepository _programingLanguageRepository;
            private readonly ProgramingLanguageBusinessRules _programingLanguageBusinessRules;
            private readonly IMapper _mapper;

            public CreateProgramingLanguageCommandHandler(IProgramingLanguageRepository programingLanguageRepository,
                ProgramingLanguageBusinessRules programingLanguageBusinessRules, IMapper mapper)
            {
                _programingLanguageRepository = programingLanguageRepository;
                _programingLanguageBusinessRules = programingLanguageBusinessRules;
                _mapper = mapper;
            }

            public async Task<bool> Handle(CreateProgramingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _programingLanguageBusinessRules.CanNotDuplicate(request.Name);
                await _programingLanguageRepository.AddAsync(_mapper.Map<ProgramingLanguage>(request));
                return true;
            }
        }
    }
}
