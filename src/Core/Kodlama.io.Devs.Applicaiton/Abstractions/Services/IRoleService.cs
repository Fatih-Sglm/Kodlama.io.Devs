using Core.Domain.Entities;
using Kodlama.io.Devs.Applicaiton.Features.Roles.Command.CreateRole;
using Kodlama.io.Devs.Applicaiton.Features.Roles.Command.UpdateRole;

namespace Kodlama.io.Devs.Applicaiton.Abstractions.Services
{
    public interface IRoleService
    {
        Task Create(CreateRoleCommand command);
        Task<IQueryable<Role>> GetRoles();
        Task Update(UpdateRoleCommand command);
    }
}
