using Kodlama.io.Devs.Applicaiton.Abstractions.Services;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.Roles.Command.UpdateRoleClaim
{
    public class UpdateRoleCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IList<Guid> OperationClaimsId { get; set; }
        public class UpdateRoleCommandCommandHandler : IRequestHandler<UpdateRoleCommand, bool>
        {
            private readonly IRoleService _roleService;

            public UpdateRoleCommandCommandHandler(IRoleService roleService)
            {
                _roleService = roleService;
            }

            public async Task<bool> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
            {
                await _roleService.Update(request);
                return true;
            }
        }
    }
}
