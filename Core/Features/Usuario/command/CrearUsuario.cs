using System.ComponentModel.DataAnnotations;
using Core.Domain.Exceptions;
using Core.Infraestructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Core.Domain.Entities;

namespace Core.Features.Usuario.command;

public record CrearUsuario : IRequest
{
    [Required]
    public string Username { get; set; }
    
    [Required]
    public string Contraseña { get; set; }
};

public class CrearUsuarioHandler : IRequestHandler<CrearUsuario>
{
    private readonly FisiolabsSofwaredbContext _context;

    public CrearUsuarioHandler(FisiolabsSofwaredbContext context)
    {
        _context = context;
    }

    public async Task Handle(CrearUsuario request, CancellationToken cancellationToken)
    {
        //Se busca si no existe algun usuario con la cuenta
        var validar = await _context.Usuarios
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Username == request.Username);

        if (validar != null)
            throw new BadRequestException("Error ya existe un usuario con el mismo nombre");
        
        var usuario = new Domain.Entities.Usuario()
        {
            Username = request.Username,
            Password = BCrypt.Net.BCrypt.HashPassword(request.Contraseña),
            Correo = "al054286@uacam.mx",
            Especialidad = "Fisioterapeuta general",
            Nacionalidad = "Mexico",
            Telefono = "9812028610"
        };

        Console.WriteLine(usuario.Password);
        
        await _context.Usuarios.AddAsync(usuario);
        await _context.SaveChangesAsync();
    }
}