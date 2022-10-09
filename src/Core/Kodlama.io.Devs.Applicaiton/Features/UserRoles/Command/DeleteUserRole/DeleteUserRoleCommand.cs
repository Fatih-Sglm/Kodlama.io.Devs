using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.UserRoles.Command.DeleteUserRole
{
    public class DeleteUserRoleCommand : IRequest<bool>
    {
        public Guid UserId { get; set; }
        public IList<Guid> RolesId { get; set; }
    }
}
