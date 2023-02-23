using Core.Domain.Entities;
using Kodlama.io.Devs.Applicaiton.Abstractions.Repositories;
using Kodlama.io.Devs.Applicaiton.Abstractions.Services;
using Kodlama.io.Devs.Applicaiton.Features.OperationClaims.Rules;
using Kodlama.io.Devs.Applicaiton.Features.Roles.Command.CreateRole;
using Kodlama.io.Devs.Applicaiton.Features.Roles.Command.UpdateRole;
using Kodlama.io.Devs.Persistence.enums;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace Kodlama.io.Devs.Persistence.Concrete.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IOperationClaimsService _operationClaimsService;
        private readonly OperationClaimsBusinessRules _operationClaimsBusinessRules;

        public RoleService(IRoleRepository roleRepository, IOperationClaimsService
            operationClaimsService, OperationClaimsBusinessRules operationClaimsBusinessRules)
        {
            _roleRepository = roleRepository;
            _operationClaimsService = operationClaimsService;
            _operationClaimsBusinessRules = operationClaimsBusinessRules;
        }

        public async Task Create(CreateRoleCommand command)
        {
            await _roleRepository.AddAsync(new()
            {
                Name = command.Name,
                OperationClaims = await OperationClaimsForeach(command.OperationClaimsId, Operations.Create, null)
            });
        }



        public async Task Update(UpdateRoleCommand command)
        {

            Role role = await _roleRepository.GetAsync(x => x.Id == command.Id, c => c.Include(x => x.OperationClaims));

            if (role.OperationClaims is not null)
                role.OperationClaims.Clear();

            if (command.OperationClaimsId is not null)
                await OperationClaimsForeach(command.OperationClaimsId, Operations.Update, role);
            role.Name = command.Name;
            await _roleRepository.UpdateAsync(role);
        }
        public async Task<IQueryable<Role>> GetRoles()
        {
            return await _roleRepository.GetAllIQueryableAsync();
        }

        private async Task<Collection<OperationClaim>> OperationClaimsForeach(IList<Guid> OperationClaimsId, Operations operations, Role role)
        {

            IQueryable<OperationClaim> operationClaims = await _operationClaimsService.GetOperationClaims();
            Collection<OperationClaim> RoleClaims = new();
            foreach (var item in OperationClaimsId)
            {
                OperationClaim operationClaim = await operationClaims.FirstOrDefaultAsync(x => x.Id == item);
                await _operationClaimsBusinessRules.CannotBeNull(operationClaim);
                switch (operations)
                {
                    case Operations.Update:
                        role.OperationClaims.Add(operationClaim);
                        break;
                    case Operations.Create:
                        RoleClaims.Add(operationClaim);
                        break;
                }

            }
            return RoleClaims;
        }


    }
}
