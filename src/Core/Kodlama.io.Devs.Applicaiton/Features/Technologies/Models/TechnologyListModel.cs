using Core.Persistence.Paging;
using Kodlama.io.Devs.Applicaiton.Features.Technologies.Dtos;

namespace Kodlama.io.Devs.Applicaiton.Features.Technologies.Models
{
    public class TechnologyListModel : BasePageableModel
    {
        public IList<GetTechnologyDto> Items { get; set; }
    }
}
