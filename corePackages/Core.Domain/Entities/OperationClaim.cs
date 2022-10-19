using Core.Domain.Base;

namespace Core.Domain.Entities;

public class OperationClaim : Entity<Guid>
{
    public string Name { get; set; }

    // public ICollection<OperationClaim> UserOperationClaims { get; set; }
    public ICollection<Role> RolesClaims { get; set; }
}