using AutoMapper;
using Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Rules;
using Kodlama.io.Devs.Applicaiton.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Command.UpdateCommand
{
    public class UpdateProgramingLanguageCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public class UpdateProgramingLanguageCommandHandler : IRequestHandler<UpdateProgramingLanguageCommand, bool>
        {
            private readonly IProgramingLanguageRepository _programingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgramingLanguageBusinessRules _programingLanguageBussinesRules;

            public UpdateProgramingLanguageCommandHandler(IProgramingLanguageRepository programingLanguageRepository, IMapper mapper, ProgramingLanguageBusinessRules programingLanguageBussinesRules)
            {
                _programingLanguageRepository = programingLanguageRepository;
                _mapper = mapper;
                _programingLanguageBussinesRules = programingLanguageBussinesRules;
            }

            public async Task<bool> Handle(UpdateProgramingLanguageCommand request, CancellationToken cancellationToken)
            {
                var pl = await _programingLanguageRepository.GetAsync(x => x.Id == request.Id);
                await _programingLanguageBussinesRules.CannotBeNull(pl);
                await _programingLanguageRepository.UpdateAsync(_mapper.Map(request, pl));
                return true;
            }
        }
    }
}
