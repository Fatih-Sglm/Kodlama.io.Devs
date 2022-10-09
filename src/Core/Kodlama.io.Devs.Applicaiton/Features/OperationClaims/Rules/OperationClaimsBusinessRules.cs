using Core.Application.BusinnesRule;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;

namespace Kodlama.io.Devs.Applicaiton.Features.OperationClaims.Rules
{
    public class OperationClaimsBusinessRules : IGenericBusinessRules<OperationClaim>
    {

        public Task CannotBeNull(OperationClaim item)
        {
            if (item == null) throw new NotFoundException("Requested Operation Claims does not exist");
            return Task.CompletedTask;
        }

        public Task CanNotDuplicate(string name)
        {
            throw new NotImplementedException();
        }
    }
}
