﻿using System.ComponentModel.DataAnnotations;
using Core.Domain.Exceptions;
using Core.Infraestructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Usuario.command;

public record CreateUser : IRequest
{
    [Required(ErrorMessage = "El campo Username es obligatorio")]
    public string Username { get; set; }
    
    [Required(ErrorMessage = "El campo Contraseña es obligatorio")]
    public string Contraseña { get; set; }
};

public class CreateUserHandler : IRequestHandler<CreateUser>
{
    private readonly FisioContext _context;
    
    public CreateUserHandler(FisioContext context)
    {
        _context = context;
    }

    public async Task Handle(CreateUser request, CancellationToken cancellationToken)
    {
        //Se busca si no existe algun usuario con la cuenta
        var validate = await _context.Usuarios
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Username == request.Username);

        if (validate != null)
            throw new BadRequestException("Error ya existe un usuario con el mismo nombre");
        
        var usuario = new Domain.Entities.Usuario()
        {
            Username = request.Username,
            Password = BCrypt.Net.BCrypt.HashPassword(request.Contraseña),
            Clave = BCrypt.Net.BCrypt.HashPassword("12345"),
            Especialidad = "Fisioterapeuta general",
            FotoPerfil = "https://res.cloudinary.com/doi0znv2t/image/upload/v1718432025/Utils/fotoPerfil.png"
        };
        
        await _context.Usuarios.AddAsync(usuario);
        await _context.SaveChangesAsync();
    }
}