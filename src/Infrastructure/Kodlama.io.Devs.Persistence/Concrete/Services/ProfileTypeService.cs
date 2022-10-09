using Kodlama.io.Devs.Applicaiton.Abstractions.Repositories;
using Kodlama.io.Devs.Applicaiton.Abstractions.Services;
using Kodlama.io.Devs.Applicaiton.Features.ProfileTypes.Command.CreateProfileType;
using Kodlama.io.Devs.Applicaiton.Features.ProfileTypes.Command.DeleteProfileType;
using Kodlama.io.Devs.Applicaiton.Features.ProfileTypes.Command.UpdateProfileType;

namespace Kodlama.io.Devs.Persistence.Concrete.Services
{
    public class ProfileTypeService : IProfileTypeService
    {
        private readonly IProfileTypeRepository _profileTypeRepository;

        public ProfileTypeService(IProfileTypeRepository profileTypeRepository)
        {
            _profileTypeRepository = profileTypeRepository;
        }

        public async Task Create(CreateProfileTypeCommand command)
        {
            await _profileTypeRepository.AddAsync(new()
            {
                PType = command.PType
            });
        }

        public Task Delete(DeleteProfileTypeCommand command)
        {
            throw new NotImplementedException();
        }

        public Task Update(UpdateProfileTypeCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
