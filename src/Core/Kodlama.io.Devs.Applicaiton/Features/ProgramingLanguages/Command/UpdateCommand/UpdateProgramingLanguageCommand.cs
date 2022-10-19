using AutoMapper;
using Kodlama.io.Devs.Applicaiton.Abstractions.Repositories;
using Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Rules;
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
            private readonly ProgramingLanguageBusinessRules _programingLanguageBusinessRules;
            private readonly IMapper _mapper;

            public UpdateProgramingLanguageCommandHandler(IProgramingLanguageRepository programingLanguageRepository,
                ProgramingLanguageBusinessRules programingLanguageBusinessRules, IMapper mapper)
            {
                _programingLanguageRepository = programingLanguageRepository;
                _programingLanguageBusinessRules = programingLanguageBusinessRules;
                _mapper = mapper;
            }

            public async Task<bool> Handle(UpdateProgramingLanguageCommand request, CancellationToken cancellationToken)
            {
                var pl = await _programingLanguageRepository.GetAsync(x => x.Id == request.Id);
                await _programingLanguageBusinessRules.CannotBeNull(pl);
                await _programingLanguageRepository.UpdateAsync(_mapper.Map(request, pl));
                return true;
            }
        }
    }
}
