using Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Models;
using Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Queries.GetListProfileLink;

namespace Kodlama.io.Devs.Applicaiton.Abstractions.Services
{
    public interface IProfileLinkService
    {
        public Task<GetListProfileLinkModel> GetUserProfileLinks(GetListProfileLinkQuery query);
    }
}
