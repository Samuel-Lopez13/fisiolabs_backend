﻿using Core.Features.Usuario;
using Core.Features.Usuario.command;
using Core.Features.Usuario.queries;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsuarioController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [AllowAnonymous]
    [HttpGet("verifyUser/{token}")]
    public async Task<VerifyUserResponse> veryUser(string token)
    {
        return await _mediator.Send(new VerifyUser(){token = token});
    }
    
    [AllowAnonymous]
    [HttpPost("Login")]
    public async Task<LoginResponse> Login([FromBody] Login command)
    {
        return await _mediator.Send(command);
    }

    [AllowAnonymous]
    [HttpPost()]
    public async Task<IActionResult> PostUsuario([FromBody] CrearUsuario command)
    {
        await _mediator.Send(command);
        return Ok("Se registro el usuario correctamente");
    }
}