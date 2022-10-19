using Core.Domain.Entities;

namespace Kodlama.io.Devs.Applicaiton.Abstractions.Services
{
    public interface IRefreshTokenService
    {
        Task InsertRefreshTokenAsync(RefreshToken refreshToken);
    }
}
