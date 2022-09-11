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
            private readonly IAuthRepository _authRepository;
            private readonly AuthBusinessRules _authBusinessRules;


            public LoginUserCommandHandler(ITokenHelper tokenHelper, IAuthRepository authRepository, AuthBusinessRules authRepositoryRules)
            {
                _tokenHelper = tokenHelper;
                _authRepository = authRepository;
                _authBusinessRules = authRepositoryRules;
            }
            public async Task<AccessToken> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {
                User user = await _authRepository.GetAsync(x => x.Email == request.Email, include: c => c.Include(c => c.UserOperationClaims).ThenInclude(c => c.OperationClaim));
                await _authBusinessRules.UserCannotBeNull(user!);
                await _authBusinessRules.CheckUserPassword(request.Password, user!);
                return _tokenHelper.CreateToken(user!, user!.UserOperationClaims.Select(item => item.OperationClaim).ToList());
            }
        }
    }
}
