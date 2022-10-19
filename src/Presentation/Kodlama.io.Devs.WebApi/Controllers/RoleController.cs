using Kodlama.io.Devs.Applicaiton.Features.Roles.Command.CreateRole;
using Kodlama.io.Devs.Applicaiton.Features.Roles.Command.DeleteRole;
using Kodlama.io.Devs.Applicaiton.Features.Roles.Command.UpdateRole;
using MediatR;

namespace Kodlama.io.Devs.WebApi.Controllers
{
    public class RoleController : BaseCrudController<CreateRoleCommand, UpdateRoleCommand, DeleteRoleCommand, IBaseRequest, IBaseRequest>
    {

        //[HttpPost]
        //public async Task<IActionResult> Create(CreateRoleCommand command)
        //{
        //    await Mediator.Send(command);
        //    return Ok();
        //}



        //[HttpPut()]
        //public async Task<IActionResult> Update([FromBody] UpdateRoleCommand updateRoleCommand)
        //{
        //    await Mediator.Send(updateRoleCommand);
        //    return Ok();
        //}
    }
}
