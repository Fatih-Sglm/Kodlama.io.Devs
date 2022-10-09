using Kodlama.io.Devs.Applicaiton.Features.Roles.Command.CreateRoleClaim;
using Kodlama.io.Devs.Applicaiton.Features.Roles.Command.DeleteRoleClaim;
using Kodlama.io.Devs.Applicaiton.Features.Roles.Command.DeleteRoleClaims;
using Kodlama.io.Devs.Applicaiton.Features.Roles.Command.UpdateRoleClaim;

namespace Kodlama.io.Devs.Applicaiton.Abstractions.Services
{
    public interface IRoleService
    {
        Task Create(CreateRoleCommand command);
        Task Delete(DeleteRoleCommand command);

        Task DeleteRoleClaims(DeleteRoleClaimsCommand command);
        //Task<PLListModel> Get(GetListProgramingLanguageQuery query);
        //Task<PLLDto> GetById(GetProgramingLanguagerQuery query);
        Task Update(UpdateRoleCommand command);
    }
}
