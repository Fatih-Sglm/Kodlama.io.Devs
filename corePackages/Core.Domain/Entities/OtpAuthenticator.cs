using Core.Domain.Base;

namespace Core.Domain.Entities;

public class OtpAuthenticator : Entity<Guid>
{
    public Guid UserId { get; set; }
    public byte[] SecretKey { get; set; }
    public bool IsVerified { get; set; }
    public User User { get; set; }
}