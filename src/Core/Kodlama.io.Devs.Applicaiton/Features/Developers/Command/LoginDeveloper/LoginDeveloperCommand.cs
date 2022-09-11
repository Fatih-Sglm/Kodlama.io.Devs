using Core.Security.Dtos;
using Core.Security.JWT;
using Kodlama.io.Devs.Applicaiton.Features.Developers.Rules;
using Kodlama.io.Devs.Applicaiton.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Applicaiton.Features.Developers.Command.LoginDeveloper
{
    public class LoginDeveloperCommand : UserForLoginDto, IRequest<AccessToken>
    {

        public class LoginDeveloperCommandHandler : IRequestHandler<LoginDeveloperCommand, AccessToken>
        {
            private readonly ITokenHelper _tokenHelper;
            private readonly IDeveloperRepository _developerRepository;
            private readonly DeveloperBusinessRules _developerBusinessRules;

            public LoginDeveloperCommandHandler(ITokenHelper tokenHelper, IDeveloperRepository developerRepository, DeveloperBusinessRules developerBusinessRules)
            {
                _tokenHelper = tokenHelper;
                _developerRepository = developerRepository;
                _developerBusinessRules = developerBusinessRules;
            }

            public async Task<AccessToken> Handle(LoginDeveloperCommand request, CancellationToken cancellationToken)
            {
                Developer? developer = await _developerRepository.GetAsync(x => x.Email == request.Email, include: c => c.Include(c => c.UserOperationClaims).ThenInclude(c => c.OperationClaim));
                await _developerBusinessRules.CannotBeNull(developer!);
                await _developerBusinessRules.EmailMustBeConfirmed(developer.IsMailConfirmed);
                await _developerBusinessRules.CheckUserPassword(request.Password, developer!);
                return _tokenHelper.CreateToken(developer!, developer!.UserOperationClaims.Select(item => item.OperationClaim).ToList());
            }
        }
    }
}
