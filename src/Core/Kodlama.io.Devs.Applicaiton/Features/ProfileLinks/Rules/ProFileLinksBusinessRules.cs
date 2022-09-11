using Core.Application.BusinnesRule;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Applicaiton.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Rules
{
    public class ProFileLinksBusinessRules : IGenericBusinessRules<ProfileLink>
    {
        private readonly IProfileLinksRepository _profileLinksRepository;

        public ProFileLinksBusinessRules(IProfileLinksRepository profileLinksRepository)
        {
            _profileLinksRepository = profileLinksRepository;
        }

        public Task CannotBeNull(ProfileLink item)
        {
            if (item == null)
                throw new NotFoundException("Requested Profile Link does not exist");
            return Task.CompletedTask;
        }

        public async Task CanNotDuplicate(string ProfileUrl)
        {
            IPaginate<ProfileLink> result = await _profileLinksRepository.GetListAsync(b => b.ProfileUrl == ProfileUrl);
            if (result.Items.Any()) throw new DuplicateException("Programing Language name exists.");
        }
    }
}
