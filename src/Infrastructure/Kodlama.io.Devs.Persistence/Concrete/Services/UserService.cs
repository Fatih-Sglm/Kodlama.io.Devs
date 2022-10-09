using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Kodlama.io.Devs.Applicaiton.Abstractions.Repositories;
using Kodlama.io.Devs.Applicaiton.Abstractions.Services;
using Kodlama.io.Devs.Applicaiton.Features.Roles.Dtos;
using Kodlama.io.Devs.Applicaiton.Features.Roles.Queries;
using Kodlama.io.Devs.Applicaiton.Features.UserRoles.Command.CreateUserRole;
using Kodlama.io.Devs.Applicaiton.Features.UserRoles.Command.DeleteUserRole;
using Kodlama.io.Devs.Applicaiton.Features.Users.Rules;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace Kodlama.io.Devs.Persistence.Concrete.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserBusinessRules _userBusinessRules;
        private readonly IRoleRepository _roleRepository;

        public UserService(IUserRepository userRepository, UserBusinessRules userBusinessRules, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _userBusinessRules = userBusinessRules;
            _roleRepository = roleRepository;
        }

        public async Task CreateUserRole(CreateUserRoleCommand command)
        {
            User user = await _userRepository.GetAsync(x => x.Id == command.UserId);
            await _userBusinessRules.CannotBeNull(user);
            var operationClaims = user.UserRole.Select(x => x.OperationClaims.ToList());
            var value = await _roleRepository.GetAllIQueryableAsync();
            Collection<Role> userrole = new();
            if (command.RolesId.Count > 0)
            {
                foreach (var item in command.RolesId)
                {
                    Role role = await value.Where(x => x.Id == item).FirstOrDefaultAsync();
                    userrole.Add(role);
                }
                user.UserRole = userrole;
                await _userRepository.UpdateAsync(user);
                return;
            }
            throw new ClientSideException("Gördermiş Olduğunuz Role Listesi Boştur!, Lütfen Tekrar deneyiniz");
        }

        public async Task DeleteRoles(DeleteUserRoleCommand command)
        {
            User user = await _userRepository.GetAsync(x => x.Id == command.UserId, c => c.Include(c => c.UserRole));
            await _userBusinessRules.CannotBeNull(user);
            foreach (var item in command.RolesId)
            {
                var claim = user.UserRole.FirstOrDefault(x => x.Id == item);
                user.UserRole.Remove(claim);
            }
            await _userRepository.UpdateAsync(user);
        }

        public async Task<GetUserRoleDto> GetUserRole(GetUserRoleQuery query)
        {
            User? user = await _userRepository.GetAsync(x => x.Id == query.UserId,
                 c => c.Include(c => c.UserRole));
            await _userBusinessRules.CannotBeNull(user);
            GetUserRoleDto getUserClaimsDto = new()
            {
                UserId = user.Id,
                Roles = user.UserRole.ToList(),
                UserName = user.FirstName + " " + user.LastName
            };
            return getUserClaimsDto;
        }
    }
}
