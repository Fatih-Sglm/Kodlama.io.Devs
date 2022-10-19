using Kodlama.io.Devs.Applicaiton.Features.Roles.Queries;
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

        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetUserRoles([FromRoute] Guid UserId)
        {
            GetUserRoleQuery query = new() { UserId = UserId };
            return Ok(await Mediator.Send(query));
        }
    }
}
