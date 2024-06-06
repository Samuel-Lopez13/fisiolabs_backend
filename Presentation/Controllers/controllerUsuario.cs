using Core.Features.Usuario;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[ApiController]
[Route("[controller]")]
public class controllerUsuario : ControllerBase
{
    private readonly IMediator _mediator;

    public controllerUsuario(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [AllowAnonymous]
    [HttpGet("usuario")]
    public async Task<UsuarioResponse> GetUsuario()
    {
        return await _mediator.Send(new ObtenerUsuariosPrueba());
    }
    
    [AllowAnonymous]
    [HttpGet("mensaje")]
    public async Task<IActionResult> GetMensaje()
    {
        return Ok("Este es un mensaje");
    }
}