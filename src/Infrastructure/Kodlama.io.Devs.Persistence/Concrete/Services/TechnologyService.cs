using AutoMapper;
using Kodlama.io.Devs.Applicaiton.Abstractions.Repositories;
using Kodlama.io.Devs.Applicaiton.Abstractions.Services;
using Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Rules;
using Kodlama.io.Devs.Applicaiton.Features.Technologies.Command.CreateTechnology;
using Kodlama.io.Devs.Applicaiton.Features.Technologies.Command.DeleteTechnology;
using Kodlama.io.Devs.Applicaiton.Features.Technologies.Command.UpdateTechnology;
using Kodlama.io.Devs.Applicaiton.Features.Technologies.Dtos;
using Kodlama.io.Devs.Applicaiton.Features.Technologies.Models;
using Kodlama.io.Devs.Applicaiton.Features.Technologies.Queries.GetListTechnology;
using Kodlama.io.Devs.Applicaiton.Features.Technologies.Queries.GetTechnology;
using Kodlama.io.Devs.Applicaiton.Features.Technologies.Rules;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Persistence.Concrete.Services
{
    public class TechnologyService : ITechnologyService
    {
        private readonly IMapper _mapper;
        private readonly ITechnologyRepository _technologyRepository;
        private readonly TechnologyBussinesRules _technologyBussinesRules;
        private readonly ProgramingLanguageBusinessRules _programingLanguageBusinessRules;

        public TechnologyService(IMapper mapper, ITechnologyRepository technologyRepository,
            TechnologyBussinesRules technologyBussinesRules, ProgramingLanguageBusinessRules programingLanguageBusinessRules)
        {
            _mapper = mapper;
            _technologyRepository = technologyRepository;
            _technologyBussinesRules = technologyBussinesRules;
            _programingLanguageBusinessRules = programingLanguageBusinessRules;
        }

        public async Task Create(CreateTechnologyCommand command)
        {
            await _programingLanguageBusinessRules.CannotBeNull(command.ProgramingLanguageId);
            Technology technology = _mapper.Map<Technology>(command);
            await _technologyBussinesRules.CannotBeNull(technology);
            await _technologyRepository.AddAsync(technology);
        }

        public Task Delete(DeleteTechnologyCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<TechnologyListModel> Get(GetListTechnologyQuery query)
        {
            throw new NotImplementedException();
        }

        public Task<GetTechnologyDto> GetById(GetTechnologyQuery query)
        {
            throw new NotImplementedException();
        }

        public Task Update(UpdateTechnologyCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
