using Kodlama.io.Devs.Applicaiton.Features.Users.Command.UpdateUser;
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
    }
}
