using Core.Application.Requests;
using Kodlama.io.Devs.Applicaiton.Features.Roles.Command.CreateRoleClaim;
using Kodlama.io.Devs.Applicaiton.Features.Roles.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebApi.Controllers
{
    public class UserOperationClaimsController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Create(CreateRoleCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }

        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetUserRoles([FromRoute] Guid UserId, [FromQuery] PageRequest pageRequest)
        {
            GetUserRoleQuery query = new() { UserId = UserId, PageRequest = pageRequest };
            return Ok(await Mediator.Send(query));
        }
    }
}
