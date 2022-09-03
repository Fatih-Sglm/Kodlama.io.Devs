using Core.Persistence.Paging;
using Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Dtos;

namespace Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Models
{
    public class PLListModel : BasePageableModel
    {
        public IList<PLLDto> Items { get; set; }
    }
}
