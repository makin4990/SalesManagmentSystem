using Application.Features.Auths.Dtos;

namespace Application.Services.AuthService;

public interface IInternalAuthentication
{
    Task<Token> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime);
    Task<Token> RefreshTokenLoginAsync(string refreshToken);
}