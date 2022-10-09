using Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Command.CreateProfileLink;
using Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Command.DeleteProfileLink;
using Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Command.UpdateProfileLink;
using Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Queries.GetListProfileLink;
using Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Queries.GetProfileLink;

namespace Kodlama.io.Devs.WebApi.Controllers
{
    public class ProfileLinksController : BaseCrudController<CreateProfileLinkCommand, UpdateProfileLinkCommand, DeleteProfileLinkCommand, GetProfileLinkQuery, GetListProfileLinkQuery>
    {
        //[HttpPost]
        //public async Task<IActionResult> Create([FromBody] CreateProfileLinkCommand command)
        //{
        //    await Mediator.Send(command);
        //    return Ok("Link Eklendi");
        //}

        //[HttpPut]
        //public async Task<IActionResult> Update([FromBody] UpdateProfileLinkCommand command)
        //{
        //    await Mediator.Send(command);
        //    return Ok("Link Güncellendi");
        //}


        //[HttpDelete("{Id}")]
        //public async Task<IActionResult> Delete([FromRoute] DeleteProfileLinkCommand command)
        //{
        //    await Mediator.Send(command);
        //    return Ok("Veri Silindi");
        //}

        //[HttpGet]
        //public async Task<IActionResult> Get([FromQuery] GetListProfileLinkQuery query)
        //{
        //    return Ok(await Mediator.Send(query));
        //}

        //[HttpGet("{Id}")]
        //public async Task<IActionResult> GetById([FromRoute] GetProfileLinkQuery query)
        //{
        //    return Ok(await Mediator.Send(query));
        //}
    }
}
