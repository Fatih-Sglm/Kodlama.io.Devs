﻿using Core.Domain.Entities;

namespace Core.Security.JWT;

public interface ITokenHelper
{
    AccessToken CreateToken(User user, IList<OperationClaim> operationClaims);

    RefreshToken CreateRefreshToken(User user, string ipAddress, int refresftokenDay);
}