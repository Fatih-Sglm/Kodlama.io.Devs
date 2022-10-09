using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Kodlama.io.Devs.Applicaiton.Abstractions.Repositories;
using Kodlama.io.Devs.Applicaiton.Abstractions.Services;
using Kodlama.io.Devs.Applicaiton.Features.OperationClaims.Rules;
using Kodlama.io.Devs.Applicaiton.Features.Roles.Command.CreateRole;
using Kodlama.io.Devs.Applicaiton.Features.Users.Rules;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq.Dynamic.Core;

namespace Kodlama.io.Devs.Persistence.Concrete.Services
{
    public class UserOperationClaimService : IUserOperationClaimService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IOperationClaimsRepository _operationClaimsRepository;
        private readonly UserBusinessRules _userBusinessRules;
        private readonly OperationClaimsBusinessRules _operationClaimsBusinessRules;
        private readonly IRoleRepository _roleRepository;

        public UserOperationClaimService(IMapper mapper, IUserRepository userRepository, IOperationClaimsRepository operationClaimsRepository, UserBusinessRules userBusinessRules, OperationClaimsBusinessRules operationClaimsBusinessRules, IRoleRepository roleRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _operationClaimsRepository = operationClaimsRepository;
            _userBusinessRules = userBusinessRules;
            _operationClaimsBusinessRules = operationClaimsBusinessRules;
            _roleRepository = roleRepository;
        }

        public async Task CreateUserClaims(CreateRoleCommand command)
        {

            User user = await _userRepository.GetAsync(x => x.Id == command.UserId);
            await _userBusinessRules.CannotBeNull(user);

            var operationClaims = user.UserRole.Select(x => x.OperationClaims.ToList());
            var value = await _roleRepository.GetAllIQueryableAsync();
            //Collection<UserOperationClaim> userclaims = new();
            //if (command.OperationClaimsId.Count > 0)
            //{
            //    foreach (var item in command.OperationClaimsId)
            //    {
            //        OperationClaim operationClaim = await value.Where(x => x.Id == item).FirstOrDefaultAsync();
            //        await _operationClaimsBusinessRules.CannotBeNull(operationClaim);

            //        UserOperationClaim userOperationClaim = new()
            //        {
            //            UserId = user.Id,
            //            OperationClaimId = item
            //        };
            //        userclaims.Add(userOperationClaim);
            //    }

            //    user.UserOperationClaims = userclaims;
            //    await _userRepository.UpdateAsync(user);
            //    return;
            Collection<Role> userrole = new();
            if (command.RolesId.Count > 0)
            {
                foreach (var item in command.RolesId)
                {
                    Role role = await value.Where(x => x.Id == item).FirstOrDefaultAsync();
                    //await _operationClaimsBusinessRules.CannotBeNull(operationClaim);

                    //UserOperationClaim userOperationClaim = new()
                    //{
                    //    UserId = user.Id,
                    //    OperationClaimId = item
                    //};
                    //userclaims.Add(userOperationClaim);
                    userrole.Add(role);
                }
                user.UserRole = userrole;
                await _userRepository.UpdateAsync(user);
                return;

            }
            throw new ClientSideException("Gördermiş Olduğunuz Role Listesi Boştur!, Lütfen Tekrar deneyiniz");

        }
    }
}
