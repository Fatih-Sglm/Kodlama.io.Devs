using AutoMapper;
using Kodlama.io.Devs.Applicaiton.Abstractions.Repositories;
using Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Dtos;
using Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Rules;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Queries.GetProgramingLanguagerQuery
{
    public class GetProgramingLanguagerQuery : IRequest<PLLDto>
    {
        public Guid Id { get; set; }
    }
    public class GetProgramingLanguagerQueryHandler : IRequestHandler<GetProgramingLanguagerQuery, PLLDto>
    {
        private readonly IProgramingLanguageRepository _programingLanguageRepository;
        private readonly ProgramingLanguageBusinessRules _programingLanguageBusinessRules;
        private readonly IMapper _mapper;

        public GetProgramingLanguagerQueryHandler(IProgramingLanguageRepository programingLanguageRepository,
            ProgramingLanguageBusinessRules programingLanguageBusinessRules, IMapper mapper)
        {
            _programingLanguageRepository = programingLanguageRepository;
            _programingLanguageBusinessRules = programingLanguageBusinessRules;
            _mapper = mapper;
        }

        public async Task<PLLDto> Handle(GetProgramingLanguagerQuery request, CancellationToken cancellationToken)
        {
            var pl = await _programingLanguageRepository.GetAsync(b => b.Id == request.Id);
            await _programingLanguageBusinessRules.CannotBeNull(pl);
            return _mapper.Map<PLLDto>(pl);
        }
    }
}
