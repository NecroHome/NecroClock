using NecroClock.Application.Models;

namespace NecroClock.Application.Interfaces
{
    public interface ITokenService
    {
        TokenResponse GenerateToken(UserModel user);
        string GenerateRefreshToken(UserModel user);
        TokenResponse RefreshToken(string refreshToken);
    }
}
