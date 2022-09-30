using Core.Security.Dtos;
using Core.Security.JWT;
using Kodlama.io.Devs.Applicaiton.Features.AppUsers.Rules;
using Kodlama.io.Devs.Applicaiton.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Applicaiton.Features.AppUsers.Command.LoginUser
{
    public class LoginUserCommand : UserForLoginDto, IRequest<AccessToken>
    {
        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, AccessToken>
        {
            private readonly ITokenHelper _tokenHelper;
            private readonly IAppUserRepository _appUserRepository;
            private readonly AppUserBusinessRules _appUserBusinessRules;

            public LoginUserCommandHandler(ITokenHelper tokenHelper, IAppUserRepository appUserRepository, AppUserBusinessRules appUserBusinessRules)
            {
                _tokenHelper = tokenHelper;
                _appUserRepository = appUserRepository;
                _appUserBusinessRules = appUserBusinessRules;
            }

            public async Task<AccessToken> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {
                AppUser appUser = await _appUserRepository.GetAsync(x => x.Email == request.Email, include: c => c.Include(c => c.UserOperationClaims).ThenInclude(c => c.OperationClaim));
                await _appUserBusinessRules.CannotBeNull(appUser!);
                await _appUserBusinessRules.CheckUserPassword(request.Password, appUser!);
                await _appUserBusinessRules.EmailMustBeConfirmed(appUser.IsMailConfirmed);
                return _tokenHelper.CreateToken(appUser!, appUser!.UserOperationClaims.Select(item => item.OperationClaim).ToList());
            }
        }
    }
}
