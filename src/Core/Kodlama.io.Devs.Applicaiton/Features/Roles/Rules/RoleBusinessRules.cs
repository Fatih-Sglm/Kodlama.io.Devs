using Core.Application.BusinnesRule;
using Core.Domain.Entities;

namespace Kodlama.io.Devs.Applicaiton.Features.Roles.Rules
{
    public class RoleBusinessRules : GenericBusinessRules<Role>
    {
        public override Task CanNotDuplicate(string name)
        {
            throw new NotImplementedException();
        }
    }
}
