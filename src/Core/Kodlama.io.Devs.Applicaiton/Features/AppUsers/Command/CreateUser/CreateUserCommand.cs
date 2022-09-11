using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Hashing;
using Kodlama.io.Devs.Applicaiton.Features.AppUsers.Rules;
using Kodlama.io.Devs.Applicaiton.Features.Common.Dtos;
using Kodlama.io.Devs.Applicaiton.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Applicaiton.Features.AppUsers.Command.CreateUser
{
    public class CreateUserCommand : UserForRegisterDto, IRequest<NoContentDto>
    {
        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, NoContentDto>
        {
            private readonly IMapper _mapper;
            private readonly AppUserBusinessRules _appUserBusinessRules;
            private readonly IAppUserRepository _appUserRepository;

            public CreateUserCommandHandler(IMapper mapper, AppUserBusinessRules appUserBusinessRules, IAppUserRepository appUserRepository)
            {
                _mapper = mapper;
                _appUserBusinessRules = appUserBusinessRules;
                _appUserRepository = appUserRepository;
            }

            public async Task<NoContentDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                await _appUserBusinessRules.CanNotDuplicate(request.Email);
                var user = _mapper.Map<AppUser>(request);
                HashingHelper.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                await _appUserRepository.AddAsync(user);
                return new();
            }
        }
    }
}
