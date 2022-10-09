using Kodlama.io.Devs.Applicaiton.Features.ProfileTypes.Command.CreateProfileType;
using Kodlama.io.Devs.Applicaiton.Features.ProfileTypes.Command.DeleteProfileType;
using Kodlama.io.Devs.Applicaiton.Features.ProfileTypes.Command.UpdateProfileType;

namespace Kodlama.io.Devs.Applicaiton.Abstractions.Services
{
    public interface IProfileTypeService
    {
        Task Create(CreateProfileTypeCommand command);
        Task Delete(DeleteProfileTypeCommand command);
        //Task<PLListModel> Get(GetListProgramingLanguageQuery query);
        //Task<PLLDto> GetById(GetProgramingLanguagerQuery query);
        Task Update(UpdateProfileTypeCommand command);
    }
}
