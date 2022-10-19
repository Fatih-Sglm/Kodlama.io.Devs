//using Kodlama.io.Devs.Applicaiton.Abstractions.Services;
//using MediatR;

//namespace Kodlama.io.Devs.Applicaiton.Features.UserRoles.Command.CreateUserRole
//{
//    public class CreateUserRoleCommand : IRequest<bool>
//    {
//        public Guid UserId { get; set; }
//        public IList<Guid>? RolesId { get; set; }
//    }

//    public class CreateUserRoleCommandHandler : IRequestHandler<CreateUserRoleCommand, bool>
//    {
//        private readonly IUserService _userService;

//        public CreateUserRoleCommandHandler(IUserService userService)
//        {
//            _userService = userService;
//        }

//        public async Task<bool> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
//        {
//            await _userService.CreateUserRole(request);
//            return true;
//        }
//    }
//}
