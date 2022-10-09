using Core.Security.Dtos;
using Core.Security.JWT;
using Kodlama.io.Devs.Applicaiton.Abstractions.Services;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Kodlama.io.Devs.Applicaiton.Features.Auths.Command.DeveloperCommand.LoginDeveloper
{
    public class LoginDeveloperCommand : UserForLoginDto, IRequest<AccessToken>
    {
        public class LoginDeveloperCommandHandler : IRequestHandler<LoginDeveloperCommand, AccessToken>
        {
            private readonly IAuthService _authService;
            private readonly IHttpContextAccessor _httpContextAccessor;

            public LoginDeveloperCommandHandler(IAuthService auhService, IHttpContextAccessor httpContextAccessor)
            {
                _authService = auhService;
                _httpContextAccessor = httpContextAccessor;
            }

            public async Task<AccessToken> Handle(LoginDeveloperCommand request, CancellationToken cancellationToken)
            {
                return await _authService.LoginDeveloper(request,
                    _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString());
            }
        }
    }
}
