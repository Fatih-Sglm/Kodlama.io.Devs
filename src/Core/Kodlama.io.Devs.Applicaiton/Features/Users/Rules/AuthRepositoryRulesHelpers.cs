using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;

namespace Kodlama.io.Devs.Applicaiton.Features.Users.Rules
{
    internal static class AuthRepositoryRulesHelpers
    {
        public static Task CheckUserPassword(string password, User user)
        {
            if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                throw new ClientSideException("Parolonız hatalı.Lütfen Tekrar deneyiniz");
            return Task.CompletedTask;
        }
    }
}