using Core.Domain.Base;

namespace Core.Domain.Entities;

public class Role : Entity<Guid>
{
    public string Name { get; set; }
    public ICollection<User> RoleUsers { get; set; }
    public ICollection<OperationClaim> OperationClaims { get; set; }
}