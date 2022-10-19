using Core.Application.BusinnesRule;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Applicaiton.Abstractions.Repositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Applicaiton.Features.ProfileTypes.Rules
{
    public class ProfileTypeBusinessRules : GenericBusinessRules<ProfileLink>
    {
        private readonly IProfileTypeRepository _profileTypeRepository;

        public ProfileTypeBusinessRules(IProfileTypeRepository profileTypeRepository)
        {
            _profileTypeRepository = profileTypeRepository;
        }
        public override async Task CanNotDuplicate(string name)
        {
            IPaginate<ProfileType> items = await _profileTypeRepository.GetListAsync();
            if (items.Items.Any()) throw new DuplicateException("Bu Profil Tipi Daha Önce Eklenmiş!!");
        }
    }
}
