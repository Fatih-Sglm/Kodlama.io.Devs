using Core.Security.Dtos;
using Core.Security.JWT;
using Kodlama.io.Devs.Applicaiton.Abstractions.Services;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Kodlama.io.Devs.Applicaiton.Features.Auths.Command.AppUsersCommand.LoginAppUser
{
    public class LoginAppUserCommand : UserForLoginDto, IRequest<AccessToken>
    {
        public class LoginUserCommandHandler : IRequestHandler<LoginAppUserCommand, AccessToken>
        {
            private readonly IAuthService _authService;
            private readonly IHttpContextAccessor _httpContextAccessor;

            public LoginUserCommandHandler(IAuthService auhService, IHttpContextAccessor httpContextAccessor)
            {
                _authService = auhService;
                _httpContextAccessor = httpContextAccessor;
            }

            public async Task<AccessToken> Handle(LoginAppUserCommand request, CancellationToken cancellationToken)
            {
                return await _authService.LoginAppUser(request, _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString());
            }
        }
    }
}
