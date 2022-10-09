using Core.Persistence.Repositories;

namespace Core.Security.Entities;

public class OtpAuthenticator : Entity
{
    public Guid UserId { get; set; }
    public byte[] SecretKey { get; set; }
    public bool IsVerified { get; set; }
    public User User { get; set; }
}