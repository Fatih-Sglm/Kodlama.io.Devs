using Core.CrossCuttingConcerns.Exceptions;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using Core.Security.Hashing;
using Kodlama.io.Devs.Applicaiton.Abstractions.Repositories;

namespace Kodlama.io.Devs.Applicaiton.Features.Auths.Rules
{
    public class AuthBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public static Task UserCannotBeNull(User user)
        {
            if (user == null)
                throw new NotFoundException("Sistemde Böyle Bir Kullanıcı Bulunmamaktadır!!");
            return Task.CompletedTask;
        }

        public async Task EmailCannotDuplicate(string email)
        {
            IPaginate<User> result = await _userRepository.GetListAsync(x => x.Email == email);
            if (result.Items.Any()) throw new NotFoundException("Bu Mail Adresi İle Daha Önce Kayıt Olunmuştur!!");

        }
        public static Task CheckUserPassword(string password, User user)
        {
            if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                throw new ClientSideException("Parolonız hatalı.Lütfen Tekrar deneyiniz!!");
            return Task.CompletedTask;
        }

        public static Task EmailMustBeConfirmed(bool isMailConfirmed)
        {
            if (!isMailConfirmed)
                throw new ClientSideException("Lütfen Emaili Doğrulayın!");
            return Task.CompletedTask;
        }
    }
}
