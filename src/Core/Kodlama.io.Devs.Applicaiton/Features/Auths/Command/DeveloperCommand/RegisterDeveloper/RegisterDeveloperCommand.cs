using Core.Security.Dtos;
using Kodlama.io.Devs.Applicaiton.Abstractions.Services;
using Kodlama.io.Devs.Applicaiton.Features.Common.Dtos;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.Auths.Command.DeveloperCommand.RegisterDeveloper
{
    public class RegisterDeveloperCommand : UserForRegisterDto, IRequest<NoContentDto>
    {
        public class RegisterDeveloperCommandHandler : IRequestHandler<RegisterDeveloperCommand, NoContentDto>
        {
            private readonly IAuthService _authService;

            public RegisterDeveloperCommandHandler(IAuthService authService)
            {
                _authService = authService;
            }

            public async Task<NoContentDto> Handle(RegisterDeveloperCommand request, CancellationToken cancellationToken)
            {
                return await _authService.RegisterDeveloper(request);
            }
        }
    }
}
