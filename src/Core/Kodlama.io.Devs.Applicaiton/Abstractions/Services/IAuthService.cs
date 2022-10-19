using Core.Domain.Entities;
using Core.Security.JWT;
using Kodlama.io.Devs.Applicaiton.Features.Auths.Command.AppUsersCommand.LoginAppUser;
using Kodlama.io.Devs.Applicaiton.Features.Auths.Command.AppUsersCommand.RegisterAppUser;
using Kodlama.io.Devs.Applicaiton.Features.Auths.Command.DeveloperCommand.LoginDeveloper;
using Kodlama.io.Devs.Applicaiton.Features.Auths.Command.DeveloperCommand.RegisterDeveloper;
using Kodlama.io.Devs.Applicaiton.Features.Common.Dtos;

namespace Kodlama.io.Devs.Applicaiton.Abstractions.Services
{
    public interface IAuthService
    {
        Task<AccessToken> LoginAppUser(LoginAppUserCommand request, string Ip);
        Task<AccessToken> LoginDeveloper(LoginDeveloperCommand request, string Ip);
        Task<NoContentDto> RegisterAppUser(RegisterAppUserCommand request);
        Task<NoContentDto> RegisterDeveloper(RegisterDeveloperCommand corequestmmand);
        Task InsertRefreshTokenAsync(RefreshToken refreshToken);
    }
}
