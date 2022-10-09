using Core.Persistence.Repositories;

namespace Core.Security.Entities;

public class OperationClaim : Entity
{
    public string Name { get; set; }

    // public ICollection<OperationClaim> UserOperationClaims { get; set; }
    public ICollection<Role> RolesClaims { get; set; }
}