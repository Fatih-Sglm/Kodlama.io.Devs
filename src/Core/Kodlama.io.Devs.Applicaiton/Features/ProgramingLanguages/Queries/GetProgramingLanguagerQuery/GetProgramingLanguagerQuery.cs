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
        private readonly ProgramingLanguageBussinesRules _programingLanguageBussinesRules;

        public GetProgramingLanguagerQueryHandler(IProgramingLanguageRepository programingLanguageRepository, IMapper mapper, ProgramingLanguageBussinesRules programingLanguageBussinesRules)
        {
            _programingLanguageRepository = programingLanguageRepository;
            _mapper = mapper;
            _programingLanguageBussinesRules = programingLanguageBussinesRules;
        }
        public async Task<PLLDto> Handle(GetProgramingLanguagerQuery request, CancellationToken cancellationToken)
        {

            var pl = await _programingLanguageBussinesRules.BrandShouldExist(request.id);
            return _mapper.Map<PLLDto>(pl);
        }
    }
}
