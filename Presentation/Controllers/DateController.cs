using Core.Features.Citas.command;
using Core.Features.Citas.queries;
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
public class DateController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public DateController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    /// <summary>
    /// Obtiene las citas del dia
    /// </summary>
    /// <remarks>
    /// Devuelve todas las citas del dia en curso
    /// </remarks>
    /// <response code="200"><b>Ok:</b>
    /// <remarks>Citas del dia</remarks>
    /// </response>
    [SwaggerResponse(StatusCodes.Status200OK)]
    [HttpGet()]
    public async Task<List<GetDailyDateResponse>> getDateDaily()
    {
        return await _mediator.Send(new GetDailyDate());
    }
    
    /// <summary>
    /// Obtiene las citas del paciente
    /// </summary>
    /// <param name="id">Id del paciente</param>
    /// <remarks>
    /// Devuelve todas las citas del paciente
    /// </remarks>
    /// <response code="200"><b>Ok:</b>
    /// <remarks>Citas del paciente</remarks>
    /// </response>
    [SwaggerResponse(StatusCodes.Status200OK)]
    [HttpGet("Paciente")]
    public async Task<List<GetDateResponse>> getDate([FromQuery] string id)
    {
        return await _mediator.Send(new GetDate(){ PacienteId = id});
    }
    
    
    /// <summary>
    /// Crea una cita para el paciente
    /// </summary>
    /// <remarks>
    /// Crea un cita para el paciente
    /// </remarks>
    /// <response code="200"><b>Ok:</b>
    /// <remarks>Se creo exitosamente la cita</remarks>
    /// </response>
    /// <response code="400"><b>Bad Request:</b>
    /// <remarks>Algun dato se lleno incorrectamente</remarks>
    /// </response>
    /// <response code="404"><b>Not Found:</b>
    /// <remarks>El Paciente con el Id proporcionado no existe</remarks>
    /// </response>
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Hubo algun fallo en el registro", typeof(ErrorResponse))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No se encontro el paciente", typeof(ErrorResponse))]
    [HttpPost()]
    public async Task<IActionResult> PostDate([FromBody] PostDate command)
    {
        await _mediator.Send(command);
        return Ok("Se creo la cita correctamente");
    }
    
    /// <summary>
    /// Modifica una cita
    /// </summary>
    /// <remarks>
    /// Modifica la parte de la cita que necesite
    /// </remarks>
    /// <response code="200"><b>Ok:</b>
    /// <remarks>Se creo modifico correctamente la cita</remarks>
    /// </response>
    /// <response code="404"><b>Not Found:</b>
    /// <remarks>La cita con el Id proporcionado no existe</remarks>
    /// </response>
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No se encontro la cita", typeof(ErrorResponse))]
    [HttpPatch()]
    public async Task<IActionResult> PatchDate([FromBody] ModifyDate command)
    {
        await _mediator.Send(command);
        return Ok("Se modifico la cita correctamente");
    }
}