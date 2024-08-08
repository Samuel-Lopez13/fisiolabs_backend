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
public class PacientesController: ControllerBase
{
    private readonly IMediator _mediator;
    
    public PacientesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    /*
    /// <summary>
    /// Obtener Pacientes
    /// </summary>
    /// <param name="pagina"></param>
    /// <remarks>
    /// Devuelve una lista de todos los pacientes, pasando como parametro la pagina
    /// </remarks>
    /// <response code="200"><b>Ok:</b>
    /// <remarks>Pacientes</remarks>
    /// </response>
    [HttpGet()]
    public async Task<GetPatientsResponse> getPatients([FromQuery] int pagina, [FromQuery] bool estatus)
    {
        return await _mediator.Send(new GetPatients() { Pagina = pagina, Estatus = estatus });
    }
    
    /// <summary>
    /// Obtiene la Data de un paciente en especifico
    /// </summary>
    /// <param name="id">Id del paciente</param>
    /// <remarks>
    /// Devuelve todos los datos de un paciente.
    /// </remarks>
    /// <response code="200"><b>Ok:</b>
    /// <remarks>Paciente</remarks>
    /// </response>
    /// <response code="404"><b>Not Found:</b>
    /// <remarks>El Id que se proporciono no es valido</remarks>
    /// </response>
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status404NotFound, "El paciente no existe", typeof(ErrorResponse))]
    [HttpGet("Paciente")]
    public async Task<PatientDataResponse> getPatient([FromQuery] string id)
    {
        return await _mediator.Send(new PatientData(){ PacienteId = id});
    }
    
    /// <summary>
    /// Buscador Pacientes
    /// </summary>
    /// <param name="página">N° Página</param>
    /// <param name="nombre">Buscar</param>
    /// <remarks>
    /// Devuelve una lista de todos los pacientes que cumplan con el criterio de busqueda, pasando como parametro la pagina
    /// </remarks>
    /// <response code="200"><b>Ok:</b>
    /// <remarks>Pacientes</remarks>
    /// </response>
    [HttpGet("Buscador")]
    public async Task<SearchPatientResponse> getSearch([FromQuery] int pagina, [FromQuery] string nombre)
    {
        return await _mediator.Send(new SearchPatients() { Pagina = pagina, Nombre = nombre});
    }

    /// <summary>
    /// Ultimos Pacientes
    /// </summary>
    /// <remarks>
    /// Devuelve los ultimos 7 pacientes que fueron registrados
    /// </remarks>
    /// <response code="200"><b>Ok:</b>
    /// <remarks>Ultimos pacientes</remarks>
    /// </response>
    [HttpGet("UltimosRegistrados")]
    public async Task<List<LastPatientsResponse>> getLastPatients()
    {
        return await _mediator.Send(new LastPatients());
    }
    
    /// <summary>
    /// Crear Paciente
    /// </summary>
    /// <param name="command">Formulario de pacientes</param>
    /// <remarks>Devuelve el Id del paciente creado</remarks>
    /// <response code="200"><b>Ok:</b>
    /// <remarks>Creado Exitosamente</remarks>
    /// </response>
    /// <response code="400"><b>Bad Request:</b>
    /// <remarks>El usuario no ingreso los datos correctamente ó El número telefonico ya existe</remarks>
    /// </response>
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Error al registrar al usuario", typeof(ErrorResponse))]
    [HttpPost()]
    public async Task<CreatePatientResponse> PostPatient([FromBody] CreatePatient command)
    {
        return await _mediator.Send(command);
    }
    
    /// <summary>
    /// Eliminar Paciente
    /// </summary>
    /// <param name="id">Id del paciente</param>
    /// <remarks>Elimina al paciente</remarks>
    /// <response code="200"><b>Ok:</b>
    /// <remarks>Eliminado Correctamente</remarks>
    /// </response>
    /// <response code="404"><b>Not Found:</b>
    /// <remarks>El Id que se proporciono no es valido</remarks>
    /// </response>
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status404NotFound, "El paciente no existe", typeof(ErrorResponse))]
    [HttpDelete()]
    public async Task<IActionResult> DeletePatient([FromQuery] string id)
    {
        await _mediator.Send(new RemovePatient() { PacienteId = id });
        return Ok("Se elimino el paciente correctamente");
    }*/
}