using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using Kodlama.io.Devs.Applicaiton.Features.Users.Rules;
using Kodlama.io.Devs.Applicaiton.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Applicaiton.Features.Users.Command.LoginUser
{
    public class LoginUserCommand : UserForLoginDto, IRequest<AccessToken>
    {
        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, AccessToken>
        {
            private readonly ITokenHelper _tokenHelper;
            private readonly IAppUserRepository _appUserRepository;
            private readonly AuthBusinessRules _authBusinessRules;


            public LoginUserCommandHandler(ITokenHelper tokenHelper, IAppUserRepository appUserRepository, AuthBusinessRules authRepositoryRules)
            {
                _tokenHelper = tokenHelper;
                _appUserRepository = appUserRepository;
                _authBusinessRules = authRepositoryRules;
            }
            public async Task<AccessToken> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {
                User user = await _appUserRepository.GetAsync(x => x.Email == request.Email, include: c => c.Include(c => c.UserOperationClaims).ThenInclude(c => c.OperationClaim));
                await _authBusinessRules.UserCannotBeNull(user!);
                await _authBusinessRules.CheckUserPassword(request.Password, user!);
                return _tokenHelper.CreateToken(user!, user!.UserOperationClaims.Select(item => item.OperationClaim).ToList());
            }
        }
    }
}
