using Core.Features.Pacientes.Command;
using Core.Features.Pacientes.queries;
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
public class ExpedienteController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public ExpedienteController(IMediator mediator)
    {
        _mediator = mediator;
    }
    /*
    /// <summary>
    /// Expediente de paciente
    /// </summary>
    /// <remarks>
    /// Devuelve un expediente con todos los datos del paciente
    /// </remarks>
    /// <param name="paciente">Id del paciente</param>
    /// <response code="200"><b>Ok:</b>
    /// <remarks>Expediente</remarks>
    /// </response>
    /// <response code="404"><b>Not Found:</b>
    /// <remarks>No existe un paciente con el Id Proporcionado</remarks>
    /// </response>
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No se encontro un paciente con el Id Proporcionado", typeof(ErrorResponse))]
    [HttpGet()]
    public async Task<GetExpedientResponse> getExpedient([FromQuery] string paciente) //
    {
        return await _mediator.Send(new GetExpedient() { PacienteId = paciente });
    }
    
    /// <summary>
    /// Crea un expediente de usuario
    /// </summary>
    /// <remarks>
    /// Crea un expediente de un usuario
    /// </remarks>
    /// <response code="200"><b>Ok:</b>
    /// <remarks>Se creo exitosamente el expediente</remarks>
    /// </response>
    /// <response code="400"><b>Bad Request:</b>
    /// <remarks>El Id que se proporciono no es valido</remarks>
    /// </response>
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Hubo algun fallo en el registro", typeof(ErrorResponse))]
    [HttpPost()]
    public async Task<IActionResult> PostExpedient([FromBody] PostExpedient command)
    {
        await _mediator.Send(command);
        return Ok("Se agregaron los datos correctamente");
    }*/
}