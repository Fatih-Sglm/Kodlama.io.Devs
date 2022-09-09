using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.io.Devs.Applicaiton.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Applicaiton.Features.ProfileLinks.Rules
{
    public class ProFileLinksBusinessRules
    {
        private readonly IProfileLinksRepository _profileLinksRepository;

        public ProFileLinksBusinessRules(IProfileLinksRepository profileLinksRepository)
        {
            _profileLinksRepository = profileLinksRepository;
        }

        public void PrfileLİnkMustExist(ProfileLink pl)
        {
            if (pl == null)
                throw new NotFoundException("Requested Profile Link does not exist");
        }
    }
}
