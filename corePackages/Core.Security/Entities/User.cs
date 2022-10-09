﻿using Core.Persistence.Repositories;
using Core.Security.Enums;

namespace Core.Security.Entities;

public class User : Entity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public byte[] PasswordSalt { get; set; }
    public byte[] PasswordHash { get; set; }
    public bool Status { get; set; }
    public bool IsMailConfirmed { get; set; } = false;
    public AuthenticatorType AuthenticatorType { get; set; }
    public ICollection<Role> UserRole { get; set; }
    //public ICollection<UserOperationClaim> UserOperationClaims { get; set; }
    public ICollection<RefreshToken> RefreshTokens { get; set; }

}