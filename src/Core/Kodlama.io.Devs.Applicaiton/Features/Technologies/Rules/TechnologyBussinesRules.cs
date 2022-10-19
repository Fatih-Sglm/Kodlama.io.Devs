using Core.Application.BusinnesRule;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Applicaiton.Abstractions.Repositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Applicaiton.Features.Technologies.Rules
{
    public class TechnologyBussinesRules : GenericBusinessRules<Technology>
    {
        private readonly ITechnologyRepository _technologyRepository;

        public TechnologyBussinesRules(ITechnologyRepository technologyRepository)
        {
            _technologyRepository = technologyRepository;
        }

        public override async Task CanNotDuplicate(string name)
        {
            IPaginate<Technology> result = await _technologyRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new DuplicateException("Programing Language name exists.");
        }
    }
}
