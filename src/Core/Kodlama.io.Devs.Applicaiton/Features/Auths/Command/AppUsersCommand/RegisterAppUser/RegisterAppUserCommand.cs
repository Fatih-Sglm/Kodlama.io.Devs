using Core.Security.Dtos;
using Kodlama.io.Devs.Applicaiton.Abstractions.Services;
using Kodlama.io.Devs.Applicaiton.Features.Common.Dtos;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.Auths.Command.AppUsersCommand.RegisterAppUser
{
    public class RegisterAppUserCommand : UserForRegisterDto, IRequest<NoContentDto>
    {
        public class RegisterAppUserHandler : IRequestHandler<RegisterAppUserCommand, NoContentDto>
        {
            private readonly IAuthService _authService;

            public RegisterAppUserHandler(IAuthService auhtService)
            {
                _authService = auhtService;
            }

            public async Task<NoContentDto> Handle(RegisterAppUserCommand request, CancellationToken cancellationToken)
            {
                return await _authService.RegisterAppUser(request);
            }
        }
    }
}
