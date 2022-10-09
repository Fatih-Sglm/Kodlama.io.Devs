using Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Command.CreateProfileLink;
using Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Command.DeleteProfileLink;
using Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Command.UpdateProfileLink;
using Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Dtos;
using Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Models;
using Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Queries.GetListProfileLink;
using Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Queries.GetProfileLink;

namespace Kodlama.io.Devs.Applicaiton.Abstractions.Services
{
    public interface IProfileLinkService
    {
        public Task Create(CreateProfileLinkCommand command);
        public Task Delete(DeleteProfileLinkCommand command);
        public Task Update(UpdateProfileLinkCommand command);
        public Task<GetProfileLinkDto> GetById(GetProfileLinkQuery query);
        public Task<GetListProfileLinkModel> Get(GetListProfileLinkQuery query);
    }
}
