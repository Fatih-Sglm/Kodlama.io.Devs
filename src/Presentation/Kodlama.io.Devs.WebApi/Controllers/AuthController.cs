using Kodlama.io.Devs.Applicaiton.Features.Users.Command.CreateUser;
using Kodlama.io.Devs.Applicaiton.Features.Users.Command.LoginUser;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebApi.Controllers
{
    public class AuthController : BaseController
    {
        [HttpPost("UserRegister")]
        public async Task<IActionResult> Register([FromBody] CreateUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        //[HttpPost("DeveloperRegister")]
        //public async Task<IActionResult> RegisterDeveloper([FromBody] CreateDeveloperCommand command)
        //{
        //    return Ok(await Mediator.Send(command));
        //}

        [HttpPost("UserLogin")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
