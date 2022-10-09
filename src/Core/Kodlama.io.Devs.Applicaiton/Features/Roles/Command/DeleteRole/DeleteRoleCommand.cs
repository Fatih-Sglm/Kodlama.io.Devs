using Kodlama.io.Devs.Applicaiton.Abstractions.Services;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.Roles.Command.DeleteRoleClaim
{
    public class DeleteRoleCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public class DeleteUserOperationClaimCommandHandler : IRequestHandler<DeleteRoleCommand, bool>
        {
            IRoleService _roleService;

            public DeleteUserOperationClaimCommandHandler(IRoleService roleService)
            {
                _roleService = roleService;
            }

            public async Task<bool> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
            {
                await _roleService.Delete(request);
                return true;
            }
        }
    }
}
