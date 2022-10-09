using Kodlama.io.Devs.Applicaiton.Abstractions.Services;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.Roles.Command.DeleteRoleClaims
{
    public class DeleteRoleClaimsCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public IList<Guid> OPerationClaimsId { get; set; }


        public class DeleteRoleClaimsCommandHandler : IRequestHandler<DeleteRoleClaimsCommand, bool>
        {
            private readonly IRoleService _roleService;

            public DeleteRoleClaimsCommandHandler(IRoleService roleService)
            {
                _roleService = roleService;
            }

            public async Task<bool> Handle(DeleteRoleClaimsCommand request, CancellationToken cancellationToken)
            {
                await _roleService.DeleteRoleClaims(request);
                return true;
            }
        }
    }
}
