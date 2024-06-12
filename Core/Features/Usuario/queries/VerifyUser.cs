﻿using Core.Domain.Exceptions;
using Core.Domain.Services;
using Core.Infraestructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Usuario.queries;

public record VerifyUser : IRequest<VerifyUserResponse>;

public class VerifyUserHandler : IRequestHandler<VerifyUser, VerifyUserResponse>
{
    private readonly FisiolabsSofwaredbContext _context;
    private readonly IAuthorization _authorization;

    public VerifyUserHandler(FisiolabsSofwaredbContext context, IAuthorization authorization)
    {
        _context = context;
        _authorization = authorization;
    }

    public async Task<VerifyUserResponse> Handle(VerifyUser request, CancellationToken cancellationToken)
    {
        var user = await _context.Usuarios.FirstOrDefaultAsync(x => x.UsuarioId == _authorization.UsuarioActual());

        bool resgistrado = true;

        if (user == null)
            resgistrado = false;
        
        var response = new VerifyUserResponse()
        {
            verify = resgistrado
        };

        return response;
    }
}

public record VerifyUserResponse
{
    public bool verify { get; set; }
}