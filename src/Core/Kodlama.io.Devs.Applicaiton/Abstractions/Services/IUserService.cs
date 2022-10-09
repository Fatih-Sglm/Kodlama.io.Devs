using Kodlama.io.Devs.Applicaiton.Features.Roles.Dtos;
using Kodlama.io.Devs.Applicaiton.Features.Roles.Queries;
using Kodlama.io.Devs.Applicaiton.Features.UserRoles.Command.CreateUserRole;
using Kodlama.io.Devs.Applicaiton.Features.UserRoles.Command.DeleteUserRole;

namespace Kodlama.io.Devs.Applicaiton.Abstractions.Services
{
    public interface IUserService
    {
        Task CreateUserRole(CreateUserRoleCommand command);
        Task DeleteRoles(DeleteUserRoleCommand command);
        Task<GetUserRoleDto> GetUserRole(GetUserRoleQuery query);
    }
}