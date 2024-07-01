using Core.Features.Usuario;
using Core.Features.Usuario.command;
using Core.Features.Usuario.queries;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;
using Swashbuckle.AspNetCore.Annotations;

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
    
    /// <summary>
    /// Verifica si el token del usuario es verdadero
    /// </summary>
    /// <remarks>Verifica si el token del usuario es verdadero</remarks>
    /// <param name="token">Token JWT</param>
    /// <response code="200"><b>Ok:</b>
    /// <remarks>Verificacion del usuario</remarks>
    /// </response>
    [AllowAnonymous]
    [HttpGet("verifyUser/{token}")]
    public async Task<VerifyUserResponse> getVeryfyUser(string token)
    {
        return await _mediator.Send(new VerifyUser(){token = token});
    }
    
    /// <summary>
    /// Login
    /// </summary>
    /// <remarks>Logearse para obtener el token de acceso</remarks>
    /// <response code="200"><b>Ok:</b>
    /// <remarks>Logeo Exitoso</remarks>
    /// </response>
    /// <response code="400"><b>Bad Request:</b>
    /// <remarks>El Nombre de Usario y la Contraseña son obligatorios</remarks>
    /// </response>
    /// <response code="404"><b>Not Found:</b>
    /// <remarks>No existe ningun usuario con esas credenciales</remarks>
    /// </response>
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Error al registrar al usuario", typeof(ErrorResponse))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No se encontro el usuario", typeof(ErrorResponse))]
    [AllowAnonymous]
    [HttpPost("Login")]
    public async Task<LoginResponse> Login([FromBody] Login command)
    {
        return await _mediator.Send(command);
    }

    /// <summary>
    /// Crea un usuario
    /// </summary>
    /// <remarks>Crea un usuario</remarks>
    /// <response code="200">><b>Ok:</b>
    /// <remarks>Se registro el usuario correctamente</remarks>
    /// </response>
    /// <response code="400">><b>Bad Request:</b>
    /// <remarks>El nombre de usuario no puede estar registrado previamente</remarks>
    /// </response>
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Error al registrar al usuario", typeof(ErrorResponse))]
    [AllowAnonymous]
    [HttpPost()]
    public async Task<IActionResult> PostUser([FromBody] CreateUser command)
    {
        await _mediator.Send(command);
        return Ok("Se registro el usuario correctamente");
    }
}