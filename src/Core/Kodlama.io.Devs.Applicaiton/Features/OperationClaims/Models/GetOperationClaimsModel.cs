using Core.Persistence.Paging;
using Kodlama.io.Devs.Applicaiton.Features.OperationClaims.Dtos;

namespace Kodlama.io.Devs.Applicaiton.Features.OperationClaims.Models
{
    public class GetOperationClaimsModel : BasePageableModel
    {
        public IList<GetOperationClaimsDto> Items { get; set; }
    }
}
