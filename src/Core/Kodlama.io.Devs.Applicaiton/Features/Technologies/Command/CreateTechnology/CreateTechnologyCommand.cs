using AutoMapper;
using Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Queries.GetProgramingLanguagerQuery;
using Kodlama.io.Devs.Applicaiton.Features.Technologies.Rules;
using Kodlama.io.Devs.Applicaiton.Services.Repositories;
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
            private readonly IMediator _mediator;

            public CreateTechnologyCommandHandler(IMapper mapper, ITechnologyRepository technologyRepository, TechnologyBussinesRules technologyBussinesRules, IMediator mediator)
            {
                _mapper = mapper;
                _technologyRepository = technologyRepository;
                _technologyBussinesRules = technologyBussinesRules;
                _mediator = mediator;
            }

            public async Task<bool> Handle(CreateTechnologyCommand request, CancellationToken cancellationToken)
            {
                GetProgramingLanguagerQuery query = new() { id = request.ProgramingLanguageId };
                await _mediator.Send(query);
                Technology technology = _mapper.Map<Technology>(request);
                await _technologyBussinesRules.CannotBeNull(technology);
                await _technologyRepository.AddAsync(technology);
                return true;
            }
        }
    }
}
