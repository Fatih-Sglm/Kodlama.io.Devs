using Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Command.CreateCommand;
using Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Command.DeleteCommand;
using Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Command.UpdateCommand;
using Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Dtos;
using Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Models;
using Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Queries.GetListProgramingLanguage;
using Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Queries.GetProgramingLanguagerQuery;

namespace Kodlama.io.Devs.Applicaiton.Abstractions.Services
{
    public interface IProgramingLanguageService
    {
        Task Create(CreateProgramingLanguageCommand command);
        Task Delete(DeleteProgramingLanguageCommand command);
        Task<PLListModel> Get(GetListProgramingLanguageQuery query);
        Task<PLLDto> GetById(GetProgramingLanguagerQuery query);
        Task Update(UpdateProgramingLanguageCommand command);
    }
}
