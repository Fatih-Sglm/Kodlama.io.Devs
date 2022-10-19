using AutoMapper;
using Core.Domain.Entities;
using Kodlama.io.Devs.Applicaiton.Abstractions.Repositories;
using Kodlama.io.Devs.Applicaiton.Abstractions.Services;
using Kodlama.io.Devs.Applicaiton.Features.Roles.Dtos;
using Kodlama.io.Devs.Applicaiton.Features.Roles.Queries;
using Kodlama.io.Devs.Applicaiton.Features.Users.AppUsers.Command.UpdateUser;
using Kodlama.io.Devs.Applicaiton.Features.Users.Rules;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace Kodlama.io.Devs.Persistence.Concrete.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserBusinessRules _userBusinessRules;
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, UserBusinessRules userBusinessRules, IRoleService roleService, IMapper mapper)
        {
            _userRepository = userRepository;
            _userBusinessRules = userBusinessRules;
            _roleService = roleService;
            _mapper = mapper;
        }

        public async Task Update(UpdateUserCommand command)
        {
            var user = await _userRepository.GetAsync(x => x.Id == command.Id, c => c.Include(x => x.UserRole));
            await _userBusinessRules.CannotBeNull(user);
            user.UserRole = await CreateUserRole(user, command.UserRoles);
            await _userRepository.UpdateAsync(_mapper.Map(command, user));
        }

        private async Task<Collection<Role>> CreateUserRole(User user, IList<Guid> Roles)
        {
            if (user.UserRole is not null)
                user.UserRole.Clear();
            if (Roles.Count > 0)
            {
                var value = await _roleService.GetRoles();
                Collection<Role> userRole = new();
                foreach (var item in Roles)
                {
                    Role role = await value.Where(x => x.Id == item).FirstOrDefaultAsync();
                    userRole.Add(role);
                }
                return userRole;
            }
            return null;
        }



        public async Task<GetUserRoleDto> GetUserRole(GetUserRoleQuery query)
        {
            User user = await _userRepository.GetAsync(x => x.Id == query.UserId,
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
