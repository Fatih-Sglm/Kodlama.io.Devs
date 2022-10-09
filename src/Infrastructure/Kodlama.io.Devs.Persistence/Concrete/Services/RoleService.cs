using Core.Security.Entities;
using Kodlama.io.Devs.Applicaiton.Abstractions.Repositories;
using Kodlama.io.Devs.Applicaiton.Abstractions.Services;
using Kodlama.io.Devs.Applicaiton.Features.OperationClaims.Rules;
using Kodlama.io.Devs.Applicaiton.Features.Roles.Command.CreateRoleClaim;
using Kodlama.io.Devs.Applicaiton.Features.Roles.Command.DeleteRoleClaim;
using Kodlama.io.Devs.Applicaiton.Features.Roles.Command.DeleteRoleClaims;
using Kodlama.io.Devs.Applicaiton.Features.Roles.Command.UpdateRoleClaim;
using Kodlama.io.Devs.Persistence.Concrete.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace Kodlama.io.Devs.Persistence.Concrete.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly OperationClaimsRepository _operationClaimsRepository;
        private readonly OperationClaimsBusinessRules _operationClaimsBusinessRules;

        public RoleService(IRoleRepository roleRepository, OperationClaimsRepository operationClaimsRepository,
            OperationClaimsBusinessRules operationClaimsBusinessRules)
        {
            _roleRepository = roleRepository;
            _operationClaimsRepository = operationClaimsRepository;
            _operationClaimsBusinessRules = operationClaimsBusinessRules;
        }

        public async Task Create(CreateRoleCommand command)
        {
            IQueryable<OperationClaim> operationClaims = await _operationClaimsRepository.GetAllIQueryableAsync();
            Collection<OperationClaim> claims = new();
            foreach (var item in command.OperationClaimsId)
            {
                claims.Add(await operationClaims.Where(x => x.Id == item).FirstOrDefaultAsync());
            }
            Role role = await _roleRepository.AddAsync(new()
            {
                Name = command.Name,
                OperationClaims = claims
            }); ;

            await _roleRepository.UpdateAsync(role);
        }

        public async Task Delete(DeleteRoleCommand command)
        {
            Role role = await _roleRepository.GetAsync(x => x.Id == command.Id);
            await _roleRepository.DeleteAsync(role);
        }

        public async Task DeleteRoleClaims(DeleteRoleClaimsCommand command)
        {
            Role role = await _roleRepository.GetAsync(x => x.Id == command.Id, c => c.Include(x => x.OperationClaims));
            IQueryable<OperationClaim> operationClaims = await _operationClaimsRepository.GetAllIQueryableAsync();
            //foreach (var item in command.OPerationClaimsId)
            //{
            //    OperationClaim operationClaim = await operationClaims.Where(x => x.Id == item).FirstOrDefaultAsync();
            //    await _operationClaimsBusinessRules.CannotBeNull(operationClaim);
            //    role.OperationClaims.Remove(operationClaim);
            //}
            await OperationClaimsForeach(role, operationClaims, command.OPerationClaimsId, "Remove");
            await _roleRepository.UpdateAsync(role);
        }

        public async Task Update(UpdateRoleCommand command)
        {

            Role role = await _roleRepository.GetAsync(x => x.Id == command.Id);
            IQueryable<OperationClaim> operationClaims = await _operationClaimsRepository.GetAllIQueryableAsync();

            //foreach (var item in command.OperationClaimsId)
            //{
            //    OperationClaim operationClaim = operationClaims.FirstOrDefault(x => x.Id == item);
            //    await _operationClaimsBusinessRules.CannotBeNull(operationClaim);
            //    role.OperationClaims.Add(operationClaim);
            //}
            await OperationClaimsForeach(role, operationClaims, command.OperationClaimsId, "Add");
            await _roleRepository.UpdateAsync(role);
        }

        private async Task OperationClaimsForeach(Role role, IQueryable<OperationClaim> operationClaims, IList<Guid> OperationClaimsId, string OperationId)
        {
            foreach (var item in OperationClaimsId)
            {
                OperationClaim operationClaim = await operationClaims.FirstOrDefaultAsync(x => x.Id == item);
                await _operationClaimsBusinessRules.CannotBeNull(operationClaim);
                switch (OperationId)
                {
                    case "Add":
                        role.OperationClaims.Add(operationClaim);
                        break;
                    case "Remove":
                        role.OperationClaims.Remove(operationClaim);
                        break;
                }
            }
        }
    }
}
