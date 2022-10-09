using Core.Application.BusinnesRule;
using Core.Security.Entities;

namespace Kodlama.io.Devs.Applicaiton.Features.Roles.Rules
{
    public class RoleBusinessRules : IGenericBusinessRules<Role>
    {
        public Task CannotBeNull(Role item)
        {
            throw new NotImplementedException();
        }

        public Task CanNotDuplicate(string name)
        {
            throw new NotImplementedException();
        }
    }
}
