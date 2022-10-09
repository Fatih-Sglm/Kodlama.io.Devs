using Core.Persistence.Repositories;

namespace Core.Security.Entities;

public class Role : Entity
{
    public string Name { get; set; }
    public ICollection<User> RoleUsers { get; set; }
    public ICollection<OperationClaim> OperationClaims { get; set; }
}