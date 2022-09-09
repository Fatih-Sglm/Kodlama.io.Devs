using Core.Persistence.Paging;
using Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Dtos;

namespace Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Models
{
    public class GetListProfileLinkModel : BasePageableModel
    {
        public IList<GetProfileLinkDto> Items { get; set; }
    }
}
