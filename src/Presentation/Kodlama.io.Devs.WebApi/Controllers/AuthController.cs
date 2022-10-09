using Kodlama.io.Devs.Applicaiton.Features.Auths.Command.AppUsersCommand.LoginAppUser;
using Kodlama.io.Devs.Applicaiton.Features.Auths.Command.AppUsersCommand.RegisterAppUser;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebApi.Controllers
{
    public class AuthController : BaseController
    {
        [HttpPost("UserRegister")]
        public async Task<IActionResult> Register([FromBody] RegisterAppUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        //[HttpPost("DeveloperRegister")]
        //public async Task<IActionResult> RegisterDeveloper([FromBody] CreateDeveloperCommand command)
        //{
        //    return Ok(await Mediator.Send(command));
        //}

        [HttpPost("UserLogin")]
        public async Task<IActionResult> Login([FromBody] LoginAppUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
