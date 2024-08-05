using Core.Features.Catalogos.command;
using Core.Features.Catalogos.queries;
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
public class CatalogoController : ControllerBase
{
    private readonly IMediator _mediator;

    public CatalogoController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    /// <summary>
    /// Catalogo Especialidades
    /// </summary>
    /// <remarks>
    /// Devuelve el catalogo de especialidades
    /// True: Devuelve solo los campos activos
    /// False: Devuelve todos los campos
    /// </remarks>
    /// <response code="200"><b>Ok:</b>
    /// <remarks>Especialidades</remarks>
    /// </response>
    [SwaggerResponse(StatusCodes.Status200OK)]
    [HttpGet("Especialidades")]
    public async Task<List<GetEspecialidadesResponse>> getEspecialidades([FromQuery] bool activo)
    {
        return await _mediator.Send(new GetEspecialidades(){ Activos = activo});
    }
    
    /// <summary>
    /// Catalogo Estado Civil
    /// </summary>
    /// <remarks>
    /// Devuelve el catalogo de estados civiles
    /// True: Devuelve solo los campos activos
    /// False: Devuelve todos los campos
    /// </remarks>
    /// <response code="200"><b>Ok:</b>
    /// <remarks>Estados Civiles</remarks>
    /// </response>
    [SwaggerResponse(StatusCodes.Status200OK)]
    [HttpGet("EstadoCivil")]
    public async Task<List<GetEstadoCivilResponse>> getEstadoCivil([FromQuery] bool activo)
    {
        return await _mediator.Send(new GetEstadoCivil(){ Activos = activo});
    }
    
    /// <summary>
    /// Catalogo Flujo Vaginal
    /// </summary>
    /// <remarks>
    /// Devuelve el catalogo de flujo vaginal
    /// True: Devuelve solo los campos activos
    /// False: Devuelve todos los campos
    /// </remarks>
    /// <response code="200"><b>Ok:</b>
    /// <remarks>Flujo Vaginal</remarks>
    /// </response>
    [SwaggerResponse(StatusCodes.Status200OK)]
    [HttpGet("FlujoVaginal")]
    public async Task<List<GetFlujoVaginalResponse>> getFlujoVaginal([FromQuery] bool activo)
    {
        return await _mediator.Send(new GetFlujoVaginal(){ Activos = activo});
    }
    
    /// <summary>
    /// Catalogo Motivo de Alta
    /// </summary>
    /// <remarks>
    /// Devuelve el catalogo de motivos de alta
    /// True: Devuelve solo los campos activos
    /// False: Devuelve todos los campos
    /// </remarks>
    /// <response code="200"><b>Ok:</b>
    /// <remarks>Motivos de Alta</remarks>
    /// </response>
    [SwaggerResponse(StatusCodes.Status200OK)]
    [HttpGet("MotivoAlta")]
    public async Task<List<GetMotivoAltaResponse>> getMotivoAlta([FromQuery] bool activo)
    {
        return await _mediator.Send(new GetMotivoAlta(){ Activos = activo});
    }
    
    /// <summary>
    /// Catalogo Servicios
    /// </summary>
    /// <remarks>
    /// Devuelve el catalogo de servicios
    /// True: Devuelve solo los campos activos
    /// False: Devuelve todos los campos
    /// </remarks>
    /// <response code="200"><b>Ok:</b>
    /// <remarks>Servicios</remarks>
    /// </response>
    [SwaggerResponse(StatusCodes.Status200OK)]
    [HttpGet("Servicios")]
    public async Task<List<GetServiciosResponse>> getServicios([FromQuery] bool activo)
    {
        return await _mediator.Send(new GetServicios(){ Activos = activo});
    }
    
    /// <summary>
    /// Catalogo Tipo Anticonceptivo
    /// </summary>
    /// <remarks>
    /// Devuelve el catalogo de tipo anticonceptivo
    /// True: Devuelve solo los campos activos
    /// False: Devuelve todos los campos
    /// </remarks>
    /// <response code="200"><b>Ok:</b>
    /// <remarks>Tipo Anticonceptivo</remarks>
    /// </response>
    [SwaggerResponse(StatusCodes.Status200OK)]
    [HttpGet("TipoAnticonceptivo")]
    public async Task<List<GetAnticonceptivoResponse>> getAnticonceptivo([FromQuery] bool activo)
    {
        return await _mediator.Send(new GetAnticonceptivo(){ Activos = activo});
    }
    
    /// <summary>
    /// Especialidades
    /// </summary>
    /// <remarks>
    /// Crea una nueva especialidad
    /// </remarks>
    /// <response code="200"><b>Ok:</b>
    /// <remarks>Se creo exitosamente</remarks>
    /// </response>
    /// <response code="400"><b>Bad Request:</b>
    /// <remarks>Datos Erroneos</remarks>
    /// </response>
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Hubo algun fallo en el registro", typeof(ErrorResponse))]
    [HttpPost("Especialidades")]
    public async Task<IActionResult> PostEspecialidades([FromBody] PostEspecialidades command)
    {
        await _mediator.Send(command);
        return Ok("Se creo correctamente");
    }
    
    /// <summary>
    /// Estado Civil
    /// </summary>
    /// <remarks>
    /// Crea un nuevo estado civil
    /// </remarks>
    /// <response code="200"><b>Ok:</b>
    /// <remarks>Se creo exitosamente</remarks>
    /// </response>
    /// <response code="400"><b>Bad Request:</b>
    /// <remarks>Datos Erroneos</remarks>
    /// </response>
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Hubo algun fallo en el registro", typeof(ErrorResponse))]
    [HttpPost("EstadoCivil")]
    public async Task<IActionResult> PostEstadoCivil([FromBody] PostEstadoCivil command)
    {
        await _mediator.Send(command);
        return Ok("Se creo correctamente");
    }
    
    /// <summary>
    /// Flujo Vaginal
    /// </summary>
    /// <remarks>
    /// Crea un nuevo flujo
    /// </remarks>
    /// <response code="200"><b>Ok:</b>
    /// <remarks>Se creo exitosamente</remarks>
    /// </response>
    /// <response code="400"><b>Bad Request:</b>
    /// <remarks>Datos Erroneos</remarks>
    /// </response>
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Hubo algun fallo en el registro", typeof(ErrorResponse))]
    [HttpPost("FlujoVaginal")]
    public async Task<IActionResult> PostFlujoVaginal([FromBody] PostFlujoVaginal command)
    {
        await _mediator.Send(command);
        return Ok("Se creo correctamente");
    }
    
    /// <summary>
    /// Motivo Alta
    /// </summary>
    /// <remarks>
    /// Crea un nuevo motivo de alta
    /// </remarks>
    /// <response code="200"><b>Ok:</b>
    /// <remarks>Se creo exitosamente</remarks>
    /// </response>
    /// <response code="400"><b>Bad Request:</b>
    /// <remarks>Datos Erroneos</remarks>
    /// </response>
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Hubo algun fallo en el registro", typeof(ErrorResponse))]
    [HttpPost("MotivoAlta")]
    public async Task<IActionResult> PostMotivoAlta([FromBody] PostMotivoAlta command)
    {
        await _mediator.Send(command);
        return Ok("Se creo correctamente");
    }
    
    /// <summary>
    /// Servicios
    /// </summary>
    /// <remarks>
    /// Crea un nuevo servicio
    /// </remarks>
    /// <response code="200"><b>Ok:</b>
    /// <remarks>Se creo exitosamente</remarks>
    /// </response>
    /// <response code="400"><b>Bad Request:</b>
    /// <remarks>Datos Erroneos</remarks>
    /// </response>
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Hubo algun fallo en el registro", typeof(ErrorResponse))]
    [HttpPost("Servicios")]
    public async Task<IActionResult> PostServicio([FromBody] PostServicios command)
    {
        await _mediator.Send(command);
        return Ok("Se creo correctamente");
    }
    
    /// <summary>
    /// Tipo Anticonceptivo
    /// </summary>
    /// <remarks>
    /// Crea un nuevo tipo de anticonceptivo
    /// </remarks>
    /// <response code="200"><b>Ok:</b>
    /// <remarks>Se creo exitosamente</remarks>
    /// </response>
    /// <response code="400"><b>Bad Request:</b>
    /// <remarks>Datos Erroneos</remarks>
    /// </response>
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Hubo algun fallo en el registro", typeof(ErrorResponse))]
    [HttpPost("TipoAnticonceptivo")]
    public async Task<IActionResult> PostTivoAnticonceptivo([FromBody] PostAnticonceptivos command)
    {
        await _mediator.Send(command);
        return Ok("Se creo correctamente");
    }
    
    /// <summary>
    /// Modifica catalogo de especialidades
    /// </summary>
    /// <response code="200"><b>Ok:</b>
    /// <remarks>Se modifico correctamente</remarks>
    /// </response>
    /// <response code="404"><b>Not Found:</b>
    /// <remarks>No existe la descripción solicitada</remarks>
    /// </response>
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No se encontro", typeof(ErrorResponse))]
    [HttpPatch("Especialidades")]
    public async Task<IActionResult> PatchEspecialidades([FromBody] PutEspecialidades command)
    {
        await _mediator.Send(command);
        return Ok("Se modifico correctamente");
    }
    
    /// <summary>
    /// Modifica catalogo de estados civiles
    /// </summary>
    /// <response code="200"><b>Ok:</b>
    /// <remarks>Se modifico correctamente</remarks>
    /// </response>
    /// <response code="404"><b>Not Found:</b>
    /// <remarks>No existe la descripción solicitada</remarks>
    /// </response>
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No se encontro", typeof(ErrorResponse))]
    [HttpPatch("EstadoCivil")]
    public async Task<IActionResult> PatchEstadoCivil([FromBody] PutEstadoCivil command)
    {
        await _mediator.Send(command);
        return Ok("Se modifico correctamente");
    }
    
    /// <summary>
    /// Modifica catalogo de Flujo Vaginal
    /// </summary>
    /// <response code="200"><b>Ok:</b>
    /// <remarks>Se modifico correctamente</remarks>
    /// </response>
    /// <response code="404"><b>Not Found:</b>
    /// <remarks>No existe la descripción solicitada</remarks>
    /// </response>
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No se encontro", typeof(ErrorResponse))]
    [HttpPatch("FlujoVaginal")]
    public async Task<IActionResult> PatchFlujo([FromBody] PutFlujoVaginal command)
    {
        await _mediator.Send(command);
        return Ok("Se modifico correctamente");
    }
    
    /// <summary>
    /// Modifica catalogo de Motivo de Alta
    /// </summary>
    /// <response code="200"><b>Ok:</b>
    /// <remarks>Se modifico correctamente</remarks>
    /// </response>
    /// <response code="404"><b>Not Found:</b>
    /// <remarks>No existe la descripción solicitada</remarks>
    /// </response>
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No se encontro", typeof(ErrorResponse))]
    [HttpPatch("MotivoAlta")]
    public async Task<IActionResult> PatchMotivoAlta([FromBody] PutMotivoAlta command)
    {
        await _mediator.Send(command);
        return Ok("Se modifico correctamente");
    }
    
    /// <summary>
    /// Modifica catalogo de Servicios
    /// </summary>
    /// <response code="200"><b>Ok:</b>
    /// <remarks>Se modifico correctamente</remarks>
    /// </response>
    /// <response code="404"><b>Not Found:</b>
    /// <remarks>No existe la descripción solicitada</remarks>
    /// </response>
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No se encontro", typeof(ErrorResponse))]
    [HttpPatch("Servicios")]
    public async Task<IActionResult> PatchServicios([FromBody] PutServicios command)
    {
        await _mediator.Send(command);
        return Ok("Se modifico correctamente");
    }
    
    /// <summary>
    /// Modifica catalogo de Tipo Anticonceptivo
    /// </summary>
    /// <response code="200"><b>Ok:</b>
    /// <remarks>Se modifico correctamente</remarks>
    /// </response>
    /// <response code="404"><b>Not Found:</b>
    /// <remarks>No existe la descripción solicitada</remarks>
    /// </response>
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No se encontro", typeof(ErrorResponse))]
    [HttpPatch("TipoAnticonceptivo")]
    public async Task<IActionResult> PatchTipoAnticonceptivo([FromBody] PutAnticonceptivo command)
    {
        await _mediator.Send(command);
        return Ok("Se modifico correctamente");
    }
}