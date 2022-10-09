using Kodlama.io.Devs.Applicaiton.Abstractions.Services;
using Kodlama.io.Devs.Applicaiton.Features.Roles.Dtos;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.Roles.Queries
{
    public class GetUserRoleQuery : IRequest<GetUserRoleDto>
    {
        public Guid UserId { get; set; }
    }

    public class GetUserRoleQueryHandler : IRequestHandler<GetUserRoleQuery, GetUserRoleDto>
    {
        private readonly IUserService _userService;

        public GetUserRoleQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<GetUserRoleDto> Handle(GetUserRoleQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetUserRole(request);
        }
    }
}
