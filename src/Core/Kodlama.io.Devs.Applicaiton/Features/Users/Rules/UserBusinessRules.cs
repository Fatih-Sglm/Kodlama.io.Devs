using Core.Application.BusinnesRule;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using Core.Security.Hashing;
using Kodlama.io.Devs.Applicaiton.Abstractions.Repositories;

namespace Kodlama.io.Devs.Applicaiton.Features.Users.Rules
{
    public class UserBusinessRules : GenericBusinessRules<User>
    {
        private readonly IAppUserRepository _appUserRepository;

        private readonly IUserRepository _userRepository;

        public UserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task EmailMustBeConfirmed(bool confirmed)
        {
            if (!confirmed)
                throw new ClientSideException("Lütfen Emaili Doğrulayın!");
            return Task.CompletedTask;
        }

        public Task CheckUserPassword(string password, User user)
        {
            if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                throw new ClientSideException("Parolonız hatalı.Lütfen Tekrar deneyiniz!!");
            return Task.CompletedTask;
        }

        public override async Task CanNotDuplicate(string email)
        {
            IPaginate<User> result = await _userRepository.GetListAsync(x => x.Email == email);
            if (result.Items.Any()) throw new NotFoundException("Bu Mail Adresi İle Daha Önce Kayıt Olunmuştur!!");
        }


    }
}
