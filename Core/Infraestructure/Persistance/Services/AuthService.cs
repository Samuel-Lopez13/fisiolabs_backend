using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Core.Domain.Exceptions;
using Core.Domain.Services;
using Core.Infraestructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Core.Features.Usuario.Command;

public class AuthService : IAuthService
{
    private readonly FisioContext _context;
    private readonly IConfiguration _configuration;
    
    public AuthService(FisioContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }
    
    public async Task<JWTSettings> AuthenticateAsync(string email, string password)
    {
        //Devuelve al usuario
        var user = await _context.Usuarios
            //.Include(u => u.Roles)
            .FirstOrDefaultAsync(x => x.Username == email && x.Password == password);
        
        //Si no es encontrado el usuario deniega el acceso
        if(user == null)
            throw new BadRequestException();
        
        //Genera un token JWT
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["JWT:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.UsuarioId.ToString()),
                new Claim(ClaimTypes.Email, user.Username)
            }),
            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        
        var token = tokenHandler.CreateToken(tokenDescriptor);
        //var expiracion = token.ValidTo;
        //return tokenHandler.WriteToken(token);
        
        var response = new JWTSettings()
        {
            Token = tokenHandler.WriteToken(token),
            Expiracion = token.ValidTo
        };

        return response;
    }
}

public record JWTSettings
{
    public string Token { get; set; }
    public DateTime Expiracion { get; set; }
}