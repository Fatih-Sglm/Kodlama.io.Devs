﻿using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Security.Hashing;
using Kodlama.io.Devs.Applicaiton.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Applicaiton.Features.Users.Rules
{
    public class AuthRepositoryRules
    {
        private readonly IAuthRepository _authRepository;

        public AuthRepositoryRules(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public Task UserCannotBeNull(User user)
        {
            if (user == null)
                throw new NotFoundException("Sİstemde Böyle Bir Kullanıcı Bulunmamaktadır");
            return Task.CompletedTask;
        }

        public async Task EmailCannotDuplicate(string email)
        {
            IPaginate<AppUser> result = await _authRepository.GetListAsync(x => x.Email == email);
            if (result.Items.Any()) throw new NotFoundException("Sİstemde Böyle Bir Kullanıcı Bulunmamaktadır");

        }
        public Task CheckUserPassword(string password, User user)
        {
            if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                throw new ClientSideException("Parolonız hatalı.Lütfen Tekrar deneyiniz");
            return Task.CompletedTask;
        }
    }
}
