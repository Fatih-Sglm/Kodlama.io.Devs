using Core.Application.BusinnesRule;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Applicaiton.Abstractions.Repositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Applicaiton.Features.ProfileTypes.Rules
{
    public class ProfileTypeBusinessRules : IGenericBusinessRules<ProfileLink>
    {
        private readonly IProfileTypeRepository _profileTypeRepository;

        public ProfileTypeBusinessRules(IProfileTypeRepository profileTypeRepository)
        {
            _profileTypeRepository = profileTypeRepository;
        }

        public Task CannotBeNull(ProfileLink item)
        {
            if (item == null) throw new NotFoundException("Böyle Bir Profil Tipi Bulunamadı!!");
            return Task.CompletedTask;
        }

        public async Task CanNotDuplicate(string name)
        {
            IPaginate<ProfileType> items = await _profileTypeRepository.GetListAsync();
            if (items.Items.Any()) throw new DuplicateException("Bu Profil Tipi Daha Önce Eklenmiş!!");
        }
    }
}
