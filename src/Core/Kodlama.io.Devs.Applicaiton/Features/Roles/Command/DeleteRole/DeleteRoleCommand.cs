using Core.Domain.Entities;
using Kodlama.io.Devs.Applicaiton.Abstractions.Repositories;
using Kodlama.io.Devs.Applicaiton.Features.Roles.Rules;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.Roles.Command.DeleteRole
{
    public class DeleteRoleCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public class DeleteUserOperationClaimCommandHandler : IRequestHandler<DeleteRoleCommand, bool>
        {
            private readonly IRoleRepository _roleRepository;
            private readonly RoleBusinessRules _roleBusinessRules;

            public DeleteUserOperationClaimCommandHandler(IRoleRepository roleRepository, RoleBusinessRules roleBusinessRules)
            {
                _roleRepository = roleRepository;
                _roleBusinessRules = roleBusinessRules;
            }

            public async Task<bool> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
            {
                Role? role = await _roleRepository.GetAsync(x => x.Id == request.Id);
                await _roleBusinessRules.CannotBeNull(role);
                await _roleRepository.DeleteAsync(role);
                return true;
            }
        }
    }
}
