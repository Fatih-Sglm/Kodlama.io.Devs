using Core.Persistence.Repositories;

namespace Core.Security.Entities;

public class EmailAuthenticator : Entity
{
    public Guid UserId { get; set; }
    public string? ActivationKey { get; set; }
    public bool IsVerified { get; set; }
    public User User { get; set; }
}