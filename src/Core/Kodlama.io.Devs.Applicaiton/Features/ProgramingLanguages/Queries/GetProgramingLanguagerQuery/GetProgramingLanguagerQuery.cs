using AutoMapper;
using Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Dtos;
using Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Rules;
using Kodlama.io.Devs.Applicaiton.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Queries.GetProgramingLanguagerQuery
{
    public class GetProgramingLanguagerQuery : IRequest<PLLDto>
    {
        public Guid id { get; set; }
    }
    public class GetProgramingLanguagerQueryHandler : IRequestHandler<GetProgramingLanguagerQuery, PLLDto>
    {
        private readonly IProgramingLanguageRepository _programingLanguageRepository;
        private readonly IMapper _mapper;
        private readonly ProgramingLanguageBusinessRules _programingLanguageBussinesRules;

        public GetProgramingLanguagerQueryHandler(IProgramingLanguageRepository programingLanguageRepository, IMapper mapper, ProgramingLanguageBusinessRules programingLanguageBussinesRules)
        {
            _programingLanguageRepository = programingLanguageRepository;
            _mapper = mapper;
            _programingLanguageBussinesRules = programingLanguageBussinesRules;
        }
        public async Task<PLLDto> Handle(GetProgramingLanguagerQuery request, CancellationToken cancellationToken)
        {
            var pl = await _programingLanguageRepository.GetAsync(b => b.Id == request.id);
            await _programingLanguageBussinesRules.CannotBeNull(pl);
            return _mapper.Map<PLLDto>(pl);
        }
    }
}
