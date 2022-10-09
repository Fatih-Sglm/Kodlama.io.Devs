using Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Command.CreateCommand;
using Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Command.DeleteCommand;
using Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Command.UpdateCommand;
using Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Queries.GetListProgramingLanguage;
using Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Queries.GetProgramingLanguagerQuery;

namespace Kodlama.io.Devs.WebApi.Controllers
{
    public class ProgramingLanguageController : BaseCrudController<CreateProgramingLanguageCommand, UpdateProgramingLanguageCommand,
        DeleteProgramingLanguageCommand, GetProgramingLanguagerQuery, GetListProgramingLanguageQuery>
    {
        //[HttpPost]
        //public async Task<IActionResult> Add([FromBody] CreateProgramingLanguageCommand command)
        //{
        //    return Ok(await Mediator.Send(command));
        //}

        //[HttpPut]
        //public async Task<IActionResult> Update([FromBody] UpdateProgramingLanguageCommand command)
        //{
        //    return Ok(await Mediator.Send(command));
        //}

        //[HttpGet]
        //public async Task<IActionResult> List([FromQuery] GetListProgramingLanguageQuery query)
        //{
        //    return Ok(await Mediator.Send(query));
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById([FromRoute] GetProgramingLanguagerQuery query)
        //{
        //    return Ok(await Mediator.Send(query));
        //}
    }
}
