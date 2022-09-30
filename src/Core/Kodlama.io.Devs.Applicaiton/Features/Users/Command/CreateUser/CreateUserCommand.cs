using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Kodlama.io.Devs.Applicaiton.Features.Users.Rules;
using Kodlama.io.Devs.Applicaiton.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.Users.Command.CreateUser
{
    public class CreateUserCommand : UserForRegisterDto, IRequest<AccessToken>
    {
        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, AccessToken>
        {
            private readonly IAppUserRepository _appUserRepository;
            private readonly IMapper _mapper;
            private readonly ITokenHelper _tokenHelper;
            private readonly AuthBusinessRules _authBusinessRules;

<<<<<<< HEAD
            public CreateUserCommandHandler(IAppUserRepository appUserRepository, IMapper mapper, ITokenHelper tokenHelper, AuthBusinessRules authBusinessRules)
=======
            public CreateUserCommandHandler(IMapper mapper, ITokenHelper tokenHelper, IAuthRepository authRepository, AuthBusinessRules authRepositoryRules)
>>>>>>> 212bc59c1aca4443429b9a7b198d9a339f2cc72f
            {
                _appUserRepository = appUserRepository;
                _mapper = mapper;
                _tokenHelper = tokenHelper;
<<<<<<< HEAD
                _authBusinessRules = authBusinessRules;
=======
                _authRepository = authRepository;
                _authBusinessRules = authRepositoryRules;
>>>>>>> 212bc59c1aca4443429b9a7b198d9a339f2cc72f
            }

            public async Task<AccessToken> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                await _authBusinessRules.EmailCannotDuplicate(request.Email);
                var user = _mapper.Map<AppUser>(request);
                HashingHelper.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user = await _appUserRepository.AddAsync(user);
                return _tokenHelper.CreateToken(user, new List<OperationClaim>() { });
            }
        }
    }
}
