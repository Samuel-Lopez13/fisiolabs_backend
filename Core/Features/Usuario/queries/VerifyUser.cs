using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Core.Domain.Exceptions;
using Core.Domain.Services;
using Core.Infraestructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Core.Features.Usuario.queries;

public record VerifyUser : IRequest<VerifyUserResponse>
{
    public string token { get; set; }
};

public class VerifyUserHandler : IRequestHandler<VerifyUser, VerifyUserResponse>
{
    private readonly FisioContext _context;
    private readonly IAuthorization _authorization;

    public VerifyUserHandler(FisioContext context, IAuthorization authorization)
    {
        _context = context;
        _authorization = authorization;
    }

    public async Task<VerifyUserResponse> Handle(VerifyUser request, CancellationToken cancellationToken)
    {
        bool response = ValidateToken(request.token);

        var resp = new VerifyUserResponse()
        {
            verify = response
        };
        
        return resp;
    }
    
    public bool ValidateToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes("jWsHs48F2v5Pj9TzY3d7QgD6eM1qZyRvXoWnEgGw"); 
        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "https://localhost:5054/",
                ValidAudience = "localhost",
                IssuerSigningKey = new SymmetricSecurityKey(key)
            }, out SecurityToken validatedToken);

            // Token es válido
            return true;
        }
        catch
        {
            // Token no es válido
            return false;
        }
    }
}

public record VerifyUserResponse
{
    public bool verify { get; set; }
}