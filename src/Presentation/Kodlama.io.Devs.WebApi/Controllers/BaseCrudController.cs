using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseCrudController<TInsert, TUpdate, TDelete, TGetIdQuery, TListQeury> : BaseController
        where TInsert : IBaseRequest
        where TUpdate : IBaseRequest
        where TDelete : IBaseRequest
        where TGetIdQuery : IBaseRequest
        where TListQeury : IBaseRequest
    {
        [HttpPost]
        public async Task<IActionResult> Create(TInsert command)
        {
            await Mediator.Send(command);
            return Ok("Link Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] TUpdate command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> List([FromQuery] TListQeury query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] TGetIdQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}
