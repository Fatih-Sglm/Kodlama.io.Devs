using Core.Application.BusinnesRule;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Applicaiton.Abstractions.Repositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Rules
{
    public class ProfileLinksBusinessRules : GenericBusinessRules<ProfileLink>
    {
        private readonly IProfileLinksRepository _profileLinksRepository;

        public ProfileLinksBusinessRules(IProfileLinksRepository profileLinksRepository)
        {
            _profileLinksRepository = profileLinksRepository;
        }



        public override async Task CanNotDuplicate(string ProfileUrl)
        {
            IPaginate<ProfileLink> result = await _profileLinksRepository.GetListAsync(b => b.ProfileUrl == ProfileUrl);
            if (result.Items.Any()) throw new DuplicateException("Profile Link  exists.");
        }
    }
}
