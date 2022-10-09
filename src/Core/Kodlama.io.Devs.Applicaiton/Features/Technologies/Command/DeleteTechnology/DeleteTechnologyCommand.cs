using Kodlama.io.Devs.Applicaiton.Abstractions.Repositories;
using Kodlama.io.Devs.Applicaiton.Features.Technologies.Rules;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.Technologies.Command.DeleteTechnology
{
    public class DeleteTechnologyCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
    public class DeleteTechnologyCommandHandler : IRequestHandler<DeleteTechnologyCommand, bool>
    {
        private readonly ITechnologyRepository _technologyRepository;
        private readonly TechnologyBussinesRules _technologyBussinesRules;

        public DeleteTechnologyCommandHandler(ITechnologyRepository technologyRepository, TechnologyBussinesRules technologyBussinesRules)
        {
            _technologyRepository = technologyRepository;
            _technologyBussinesRules = technologyBussinesRules;
        }

        public async Task<bool> Handle(DeleteTechnologyCommand request, CancellationToken cancellationToken)
        {
            Technology? technology = await _technologyRepository.GetAsync(x => x.Id == request.Id);
            await _technologyBussinesRules.CannotBeNull(technology);
            await _technologyRepository.DeleteAsync(technology);
            return true;
        }
    }
}
