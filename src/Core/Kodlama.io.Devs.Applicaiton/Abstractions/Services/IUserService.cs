using Kodlama.io.Devs.Applicaiton.Features.Roles.Dtos;
using Kodlama.io.Devs.Applicaiton.Features.Roles.Queries;
using Kodlama.io.Devs.Applicaiton.Features.Users.AppUsers.Command.UpdateUser;

namespace Kodlama.io.Devs.Applicaiton.Abstractions.Services
{
    public interface IUserService
    {
        Task Update(UpdateUserCommand command);
        Task<GetUserRoleDto> GetUserRole(GetUserRoleQuery query);
    }
}