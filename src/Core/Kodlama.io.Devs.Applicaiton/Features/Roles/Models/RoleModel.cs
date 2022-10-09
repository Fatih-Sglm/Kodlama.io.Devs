using Core.Persistence.Paging;
using Kodlama.io.Devs.Applicaiton.Features.Roles.Dtos;

namespace Kodlama.io.Devs.Applicaiton.Features.Roles.Models
{
    public class RoleModel : BasePageableModel
    {
        public IList<GetUserRoleDto> Items { get; set; }
    }
}
