using AutoMapper;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Kodlama.io.Devs.Applicaiton.Abstractions.Repositories;
using Kodlama.io.Devs.Applicaiton.Abstractions.Services;
using Kodlama.io.Devs.Applicaiton.Features.Auths.Command.AppUsersCommand.LoginAppUser;
using Kodlama.io.Devs.Applicaiton.Features.Auths.Command.AppUsersCommand.RegisterAppUser;
using Kodlama.io.Devs.Applicaiton.Features.Auths.Command.DeveloperCommand.LoginDeveloper;
using Kodlama.io.Devs.Applicaiton.Features.Auths.Command.DeveloperCommand.RegisterDeveloper;
using Kodlama.io.Devs.Applicaiton.Features.Auths.Rules;
using Kodlama.io.Devs.Applicaiton.Features.Common.Dtos;
using Kodlama.io.Devs.Applicaiton.Features.Users.Rules;
using Kodlama.io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Infrastructure.Service
{
    public class AuthService : IAuthService
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IDeveloperRepository _developerRepository;
        private readonly IAppUserRepository _appUserRepository;
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly IMapper _mapper;
        private readonly UserBusinessRules _userBusinessRules;

        public AuthService(ITokenHelper tokenHelper, IRefreshTokenRepository
            refreshTokenRepository, IDeveloperRepository developerRepository,
            IAppUserRepository appUserRepository, AuthBusinessRules
            authBusinessRules, IMapper mapper, UserBusinessRules userBusinessRules)
        {
            _tokenHelper = tokenHelper;
            _refreshTokenRepository = refreshTokenRepository;
            _developerRepository = developerRepository;
            _appUserRepository = appUserRepository;
            _authBusinessRules = authBusinessRules;
            _mapper = mapper;
            _userBusinessRules = userBusinessRules;
        }

        public async Task InsertRefreshTokenTokenAsync(RefreshToken refreshToken)
        {
            await _refreshTokenRepository.AddAsync(refreshToken);
        }

        public async Task<AccessToken> LoginAppUser(LoginAppUserCommand request, string Ip)
        {
            AppUser appUser = await _appUserRepository.GetAsync(x => x.Email == request.Email, include: c => c.Include(c => c.UserRole).ThenInclude(c => c.OperationClaims));
            await AuthBusinessRules.UserCannotBeNull(appUser!);
            await AuthBusinessRules.CheckUserPassword(request.Password, appUser!);
            await AuthBusinessRules.EmailMustBeConfirmed(appUser.IsMailConfirmed);
            await InsertRefreshTokenTokenAsync(_tokenHelper.CreateRefreshToken(appUser, Ip, 1));
            return _tokenHelper.CreateToken(appUser!, appUser.UserRole.SelectMany(x => x.OperationClaims).ToList());
        }

        public async Task<AccessToken> LoginDeveloper(LoginDeveloperCommand request, string Ip)
        {
            Developer developer = await _developerRepository.GetAsync(x => x.Email == request.Email, include: c => c.Include(c => c.UserRole).ThenInclude(c => c.OperationClaims));
            await _userBusinessRules.CannotBeNull(developer);
            await _userBusinessRules.CheckUserPassword(request.Password, developer);
            await _userBusinessRules.EmailMustBeConfirmed(developer.IsMailConfirmed);
            await InsertRefreshTokenTokenAsync(_tokenHelper.CreateRefreshToken(developer, Ip, 1));
            return _tokenHelper.CreateToken(developer!, developer.UserRole.SelectMany(x => x.OperationClaims).ToList());
        }

        public async Task<NoContentDto> RegisterAppUser(RegisterAppUserCommand request)
        {
            await _authBusinessRules.EmailCannotDuplicate(request.Email);
            var user = _mapper.Map<AppUser>(request);
            HashingHelper.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            await _appUserRepository.AddAsync(user);
            return new();
        }

        public async Task<NoContentDto> RegisterDeveloper(RegisterDeveloperCommand request)
        {
            var developer = _mapper.Map<Developer>(request);
            HashingHelper.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            developer.PasswordHash = passwordHash;
            developer.PasswordSalt = passwordSalt;
            await _developerRepository.AddAsync(developer);
            return new();
        }
    }
}
