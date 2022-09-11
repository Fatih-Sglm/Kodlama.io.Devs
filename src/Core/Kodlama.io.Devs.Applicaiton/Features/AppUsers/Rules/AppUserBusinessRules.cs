using Core.Application.BusinnesRule;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Security.Hashing;
using Kodlama.io.Devs.Applicaiton.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Applicaiton.Features.AppUsers.Rules
{
    public class AppUserBusinessRules : IGenericBusinessRules<AppUser>
    {
        private readonly IAppUserRepository _appUserRepository;

        public AppUserBusinessRules(IAppUserRepository userRepository)
        {
            _appUserRepository = userRepository;
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

        public async Task CanNotDuplicate(string email)
        {
            IPaginate<AppUser> result = await _appUserRepository.GetListAsync(x => x.Email == email);
            if (result.Items.Any()) throw new NotFoundException("Bu Mail Adresi İle Daha Önce Kayıt Olunmuştur!!");
        }

        public Task CannotBeNull(AppUser item)
        {
            if (item == null)
                throw new NotFoundException("Sistemde Böyle Bir Kullanıcı Bulunmamaktadır!!");
            return Task.CompletedTask;
        }
    }
}
