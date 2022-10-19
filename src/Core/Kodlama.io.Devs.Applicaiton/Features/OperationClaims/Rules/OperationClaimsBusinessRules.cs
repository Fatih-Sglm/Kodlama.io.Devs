using Core.Application.BusinnesRule;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Domain.Entities;

namespace Kodlama.io.Devs.Applicaiton.Features.OperationClaims.Rules
{
    public class OperationClaimsBusinessRules : GenericBusinessRules<OperationClaim>
    {

        public Task CannotBeNull(OperationClaim item)
        {
            if (item == null) throw new NotFoundException("");
            return Task.CompletedTask;
        }
        public override Task CanNotDuplicate(string name)
        {
            throw new NotImplementedException();
        }
    }
}
