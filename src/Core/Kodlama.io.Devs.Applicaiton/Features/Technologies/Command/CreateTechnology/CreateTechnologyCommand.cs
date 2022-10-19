using AutoMapper;
using Kodlama.io.Devs.Applicaiton.Abstractions.Repositories;
using Kodlama.io.Devs.Applicaiton.Abstractions.Services;
using Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Rules;
using Kodlama.io.Devs.Applicaiton.Features.Technologies.Rules;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.Technologies.Command.CreateTechnology
{
    public class CreateTechnologyCommand : IRequest<bool>
    {

        public string Name { get; set; }
        public Guid ProgramingLanguageId { get; set; }

        public class CreateTechnologyCommandHandler : IRequestHandler<CreateTechnologyCommand, bool>
        {
            private readonly IMapper _mapper;
            private readonly ITechnologyRepository _technologyRepository;
            private readonly TechnologyBussinesRules _technologyBussinesRules;
            private readonly ProgramingLanguageBusinessRules _programingLanguageBusinessRules;
            private readonly IProgramingLanguageService _programingLanguageService;

            public CreateTechnologyCommandHandler(IMapper mapper, ITechnologyRepository technologyRepository,
                TechnologyBussinesRules technologyBussinesRules, ProgramingLanguageBusinessRules programingLanguageBusinessRules, IProgramingLanguageService programingLanguageService)
            {
                _mapper = mapper;
                _technologyRepository = technologyRepository;
                _technologyBussinesRules = technologyBussinesRules;
                _programingLanguageBusinessRules = programingLanguageBusinessRules;
                _programingLanguageService = programingLanguageService;
            }

            public async Task<bool> Handle(CreateTechnologyCommand request, CancellationToken cancellationToken)
            {
                ProgramingLanguage? pl = await _programingLanguageService.GetById(request.ProgramingLanguageId);
                await _programingLanguageBusinessRules.CannotBeNull(pl);
                Technology technology = _mapper.Map<Technology>(request);
                await _technologyBussinesRules.CannotBeNull(technology);
                await _technologyRepository.AddAsync(technology);
                return true;
            }
        }
    }
}
