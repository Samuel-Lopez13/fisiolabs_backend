﻿using System.ComponentModel.DataAnnotations;
using Core.Domain.Exceptions;
using Core.Domain.Helpers;
using Core.Domain.Services;
using Core.Infraestructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Usuario.command;

public record Login : IRequest<LoginResponse>
{
    [Required]
    public string Username { get; set; }
    
    [Required]
    public string Contraseña { get; set; }
};

public class LoginHandler : IRequestHandler<Login, LoginResponse>
{
    private readonly FisioContext _context;
    private readonly IAuthService _authService;

    public LoginHandler(FisioContext context, IAuthService authService)
    {
        _context = context;
        _authService = authService;
    }

    public async Task<LoginResponse> Handle(Login request, CancellationToken cancellationToken)
    {
        //Valida que no esten vacias
        if(string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Contraseña))
            throw new BadRequestException("Username y contraseña son obligatorios");
        
        //Se busca al usuario propietario del username
        var user = await _context.Usuarios
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Username == request.Username);

        if (user == null)
            throw new NotFoundException("El usuario no se encuentra registrado");
        
        //Se compara la contraseña para verificar que sean las mismas
        var password = BCrypt.Net.BCrypt.Verify(request.Contraseña, user.Password) ? user.Password : request.Contraseña;
        
        //Si cumple con las validaciones se procede a autenticar
        var token = await _authService.AuthenticateAsync(request.Username, password);
        
        var response = new LoginResponse()
        {
            Success = true,
            AccessToken = token.Token,
            Vigencia = token.Expiracion,
            User = new UserDate()
            {
                Id = user.UsuarioId.HashId(),
                Username = user.Username
            }
        };

        return response;
    }
}

public record LoginResponse
{
    public bool Success { get; set; }
    public string AccessToken { get; set; }
    public DateTime Vigencia { get; set; }
    public UserDate User { get; set; }
}

public record UserDate
{
    public string Id { get; set; }
    public string Username { get; init; }
}