using Core.Application.BusinnesRule;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Kodlama.io.Devs.Applicaiton.Services.Repositories;

namespace Kodlama.io.Devs.Applicaiton.Features.UserOperationClaims.Rules
{
    public class UserOperationClaimsBusinessRules : IGenericBusinessRules<UserOperationClaim>
    {
        private readonly IUserOperationClaimsRepository _userOperationClaimsRepository;

        public UserOperationClaimsBusinessRules(IUserOperationClaimsRepository userOperationClaimsRepository)
        {
            _userOperationClaimsRepository = userOperationClaimsRepository;
        }

        public Task CannotBeNull(UserOperationClaim item)
        {
            if (item == null) throw new NotFoundException("");
            return Task.CompletedTask;
        }

        public async Task CanNotDuplicate(string name)
        {
            IPaginate<UserOperationClaim> items = await _userOperationClaimsRepository.GetListAsync();
            if (items.Items.Any()) throw new DuplicateException("");
        }
    }
}
