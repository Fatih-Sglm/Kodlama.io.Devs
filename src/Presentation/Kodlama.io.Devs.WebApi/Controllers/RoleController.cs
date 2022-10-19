using Kodlama.io.Devs.Applicaiton.Features.Roles.Command.CreateRole;
using Kodlama.io.Devs.Applicaiton.Features.Roles.Command.DeleteRoleClaims;
using Kodlama.io.Devs.Applicaiton.Features.Roles.Command.UpdateRole;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebApi.Controllers
{
    public class RoleController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Create(CreateRoleCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteRoleClaims([FromBody] DeleteRoleClaimsCommand deleteRoleClaimsCommand)
        {
            await Mediator.Send(deleteRoleClaimsCommand);
            return Ok();
        }

        [HttpPut()]
        public async Task<IActionResult> Update([FromBody] UpdateRoleCommand updateRoleCommand)
        {
            await Mediator.Send(updateRoleCommand);
            return Ok();
        }
    }
}
