using Core.Domain.Entities;

namespace Kodlama.io.Devs.Applicaiton.Features.Roles.Dtos
{
    public class GetUserRoleDto
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public IList<Role> Roles { get; set; }
    }
}
