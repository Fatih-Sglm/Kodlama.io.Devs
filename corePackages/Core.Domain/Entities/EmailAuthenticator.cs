using Core.Domain.Base;

namespace Core.Domain.Entities;

public class EmailAuthenticator : Entity<Guid>
{
    public Guid UserId { get; set; }
    public string? ActivationKey { get; set; }
    public bool IsVerified { get; set; }
    public User User { get; set; }
}