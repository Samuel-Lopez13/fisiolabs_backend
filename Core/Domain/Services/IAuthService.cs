using Core.Features.Usuario.Command;

namespace Core.Domain.Services;

public interface IAuthService
{
    Task<JWTSettings> AuthenticateAsync(string email, string password);
}