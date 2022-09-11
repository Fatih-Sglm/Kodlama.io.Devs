using Kodlama.io.Devs.Applicaiton.Features.Technologies.Command.CreateTechnology;
using Kodlama.io.Devs.Applicaiton.Features.Technologies.Command.UpdateTechnology;
using Kodlama.io.Devs.Applicaiton.Features.Technologies.Queries.GetListTechnology;
using Kodlama.io.Devs.Applicaiton.Features.Technologies.Queries.GetTechnology;
using Microsoft.AspNetCore.Mvc;
#pragma warning disable CS8602 // Dereference of a possibly null reference.

namespace Kodlama.io.Devs.WebApi.Controllers
{
    public class TechnologyController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTechnologyCommand command)
        {

            await Mediator.Send(command);
            return Ok("Veri Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTechnologyCommand command)
        {
            await Mediator.Send(command);
            return Ok("Veri Güncellendi");
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetListTechnologyQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetTechnologyQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}
