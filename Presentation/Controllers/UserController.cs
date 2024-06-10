using Core.Features.Usuario;
using Core.Features.Usuario.command;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [AllowAnonymous]
    [HttpPost("Login")]
    public async Task<LoginResponse> Login([FromBody] Login command)
    {
        return await _mediator.Send(command);
    }

    [AllowAnonymous]
    [HttpPost("usuario")]
    public async Task<IActionResult> PostUsuario([FromBody] CrearUsuario command)
    {
        await _mediator.Send(command);
        return Ok("Se registro el usuario correctamente");
    }
}