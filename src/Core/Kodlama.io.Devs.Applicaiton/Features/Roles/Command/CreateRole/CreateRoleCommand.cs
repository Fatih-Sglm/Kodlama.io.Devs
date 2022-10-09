using Kodlama.io.Devs.Applicaiton.Abstractions.Services;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.Roles.Command.CreateRole
{
    public class CreateRoleCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public IList<Guid>? OperationClaimsId { get; set; }
    }

    public class CreateUserOperationClaimsCommandHandler : IRequestHandler<CreateRoleCommand, bool>
    {
        private readonly IRoleService _roleService;

        public CreateUserOperationClaimsCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<bool> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            await _roleService.Create(request);
            return true;
        }
    }
}
