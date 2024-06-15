using System.Reflection;
using System.Text;
using Core.Domain.Services;
using Core.Features.Usuario.Command;
using Core.Infraestructure.Persistance;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Core.Infraestructure;

public static class ConfigureServices
{
    public static IServiceCollection AddSecurity(this IServiceCollection services, IConfiguration config)
    {
        //Inyeccion de la Intefaz con su implementacion
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IConvertToBase64, ConvertToBase64>();
        services.AddScoped<IUploadFile, UploadFiles>();
        services.AddScoped<IValidateFiles, ValidateFiles>();
        
        services.AddAuthorization();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"])),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });
        
        return services;
    }
}