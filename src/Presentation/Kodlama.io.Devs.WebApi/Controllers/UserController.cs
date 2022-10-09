using Kodlama.io.Devs.Applicaiton.Features.Roles.Command.UpdateRole;
using Kodlama.io.Devs.Applicaiton.Features.Users.AppUsers.Command.UpdateUser;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebApi.Controllers
{

    public class UserController : BaseController
    {
        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserCommand command)
        {
            await Mediator.Send(command);
            return Ok("Güncelleme Başarılı");
        }

        [HttpPut("USerOperationClaim")]
        public async Task<IActionResult> UserOperationClaim(UpdateRoleCommand command)
        {
            await Mediator.Send(command);
            return Ok("Güncelleme Başarılı");
        }
    }
}
