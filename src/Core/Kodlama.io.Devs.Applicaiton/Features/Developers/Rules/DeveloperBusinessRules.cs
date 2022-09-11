using Core.Application.BusinnesRule;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Hashing;
using Kodlama.io.Devs.Applicaiton.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Applicaiton.Features.Developers.Rules
{
    public class DeveloperBusinessRules : IGenericBusinessRules<Developer>
    {
        private readonly IDeveloperRepository _developerRepository;

        public DeveloperBusinessRules(IDeveloperRepository developerRepository)
        {
            _developerRepository = developerRepository;
        }

        public Task EmailMustBeConfirmed(bool confirmed)
        {
            if (!confirmed)
                throw new ClientSideException("Lütfen Emaili Doğrulayın!");
            return Task.CompletedTask;
        }

        public Task CheckUserPassword(string password, Developer developer)
        {
            if (!HashingHelper.VerifyPasswordHash(password, developer.PasswordHash, developer.PasswordSalt))
                throw new ClientSideException("Parolonız hatalı.Lütfen Tekrar deneyiniz!!");
            return Task.CompletedTask;
        }

        public async Task CanNotDuplicate(string email)
        {
            IPaginate<Developer> result = await _developerRepository.GetListAsync(x => x.Email == email);
            if (result.Items.Any()) throw new NotFoundException("Bu Mail Adresi İle Daha Önce Kayıt Olunmuştur!!");
        }

        public Task CannotBeNull(Developer item)
        {
            if (item == null)
                throw new NotFoundException("Sistemde Böyle Bir Kullanıcı Bulunmamaktadır!!");
            return Task.CompletedTask;
        }
    }
}
