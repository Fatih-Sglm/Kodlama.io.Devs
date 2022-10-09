using Kodlama.io.Devs.Applicaiton.Abstractions.Services;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.UserRoles.Command.UpdateUserRole
{
    public class UpdateUserRoleCommand : IRequest<bool>
    {


        public class UpdateUserRoleCommandHandler : IRequestHandler<UpdateUserRoleCommand, bool>
        {
            private readonly IUserService _userService;

            public UpdateUserRoleCommandHandler(IUserService userService)
            {
                _userService = userService;
            }
            public Task<bool> Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
