using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Applicaiton.Abstractions.Repositories;
using Kodlama.io.Devs.Applicaiton.Abstractions.Services;
using Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Command.CreateCommand;
using Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Command.DeleteCommand;
using Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Command.UpdateCommand;
using Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Dtos;
using Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Models;
using Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Queries.GetListProgramingLanguage;
using Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Queries.GetProgramingLanguagerQuery;
using Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Rules;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Persistence.Concrete.Services
{
    public class ProgramingLanguageService : IProgramingLanguageService
    {
        private readonly IProgramingLanguageRepository _programingLanguageRepository;
        private readonly IMapper _mapper;
        private readonly ProgramingLanguageBusinessRules _programingLanguageBusinessRules;

        public ProgramingLanguageService(IProgramingLanguageRepository programingLanguageRepository,
            IMapper mapper, ProgramingLanguageBusinessRules programingLanguageBusinessRules)
        {
            _programingLanguageRepository = programingLanguageRepository;
            _mapper = mapper;
            _programingLanguageBusinessRules = programingLanguageBusinessRules;
        }

        public async Task Create(CreateProgramingLanguageCommand command)
        {
            await _programingLanguageBusinessRules.CanNotDuplicate(command.Name);
            await _programingLanguageRepository.AddAsync(_mapper.Map<ProgramingLanguage>(command));
        }

        public async Task Delete(DeleteProgramingLanguageCommand command)
        {
            ProgramingLanguage? programingLanguage = await _programingLanguageRepository.GetAsync(x => x.Id == Guid.Parse(command.Id));
            await _programingLanguageBusinessRules.CannotBeNull(programingLanguage);
            await _programingLanguageRepository.DeleteAsync(programingLanguage);
        }

        public async Task<PLListModel> Get(GetListProgramingLanguageQuery query)
        {
            IPaginate<ProgramingLanguage> pl = await _programingLanguageRepository.GetListAsync(index: query.PageRequest.Page, size: query.PageRequest.PageSize);
            return _mapper.Map<PLListModel>(pl);
        }

        public async Task<PLLDto> GetById(GetProgramingLanguagerQuery query)
        {
            var pl = await _programingLanguageRepository.GetAsync(b => b.Id == query.Id);
            await _programingLanguageBusinessRules.CannotBeNull(pl);
            return _mapper.Map<PLLDto>(pl);
        }

        public async Task Update(UpdateProgramingLanguageCommand command)
        {
            var pl = await _programingLanguageRepository.GetAsync(x => x.Id == command.Id);
            await _programingLanguageBusinessRules.CannotBeNull(pl);
            await _programingLanguageRepository.UpdateAsync(_mapper.Map(command, pl));
        }
    }
}
