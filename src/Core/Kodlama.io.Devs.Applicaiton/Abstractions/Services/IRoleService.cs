using Kodlama.io.Devs.Applicaiton.Features.Roles.Command.CreateRole;
using Kodlama.io.Devs.Applicaiton.Features.Roles.Command.DeleteRole;
using Kodlama.io.Devs.Applicaiton.Features.Roles.Command.DeleteRoleClaims;
using Kodlama.io.Devs.Applicaiton.Features.Roles.Command.UpdateRole;

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
