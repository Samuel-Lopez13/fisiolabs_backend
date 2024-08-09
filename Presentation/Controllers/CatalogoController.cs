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
    /// Catalogo de especialidades
    /// </summary>
    /// <remarks>
    /// Devuelve una lista de las especialidades de los fisioterapeutas
    /// <br/>
    /// <b>onlyActive:</b> Si no se devuelve ningun valor, por defecto sera <b>False</b>
    /// </remarks>
    /// <param name="onlyActive"><b>True: </b>solo devolvera a los activos, <b>False: </b> Devuelve todos los datos</param>
    /// <response code="200"><b>Ok:</b>
    /// <remarks>Especialidades</remarks>
    /// </response>
    [SwaggerResponse(StatusCodes.Status200OK)]
    [HttpGet("Especialidades")]
    public async Task<List<GetEspecialidadesResponse>> getEspecialidades([FromQuery] bool onlyActive)
    {
        return await _mediator.Send(new GetEspecialidades(){ OnlyActive = onlyActive});
    }
    
    /// <summary>
    /// Catalogo Estado Civil
    /// </summary>
    /// <remarks>
    /// Devuelve una lista de los tipos de estado civil
    /// <br/>
    /// <b>onlyActive:</b> Si no se devuelve ningun valor, por defecto sera <b>False</b>
    /// </remarks>
    /// <param name="onlyActive"><b>True: </b>solo devolvera a los activos, <b>False: </b> Devuelve todos los datos</param>
    /// <response code="200"><b>Ok:</b>
    /// <remarks>Estados Civiles</remarks>
    /// </response>
    [SwaggerResponse(StatusCodes.Status200OK)]
    [HttpGet("EstadoCivil")]
    public async Task<List<GetEstadoCivilResponse>> getEstadoCivil([FromQuery] bool onlyActive)
    {
        return await _mediator.Send(new GetEstadoCivil(){ OnlyActive = onlyActive});
    }
    
    /// <summary>
    /// Catalogo Flujo Vaginal
    /// </summary>
    /// <remarks>
    /// Devuelve una lista de los tipos de flujo vaginal
    /// <br/>
    /// <b>onlyActive:</b> Si no se devuelve ningun valor, por defecto sera <b>False</b>
    /// </remarks>
    /// <param name="onlyActive"><b>True: </b>solo devolvera a los activos, <b>False: </b> Devuelve todos los datos</param>
    /// <response code="200"><b>Ok:</b>
    /// <remarks>Flujo Vaginal</remarks>
    /// </response>
    [SwaggerResponse(StatusCodes.Status200OK)]
    [HttpGet("FlujoVaginal")]
    public async Task<List<GetFlujoVaginalResponse>> getFlujoVaginal([FromQuery] bool onlyActive)
    {
        return await _mediator.Send(new GetFlujoVaginal(){ OnlyActive = onlyActive});
    }
    
    /// <summary>
    /// Catalogo Motivo de Alta
    /// </summary>
    /// <remarks>
    /// Devuelve una lista de los motivos de alta
    /// <br/>
    /// <b>onlyActive:</b> Si no se devuelve ningun valor, por defecto sera <b>False</b>
    /// </remarks>
    /// <param name="onlyActive"><b>True: </b>solo devolvera a los activos, <b>False: </b> Devuelve todos los datos</param>
    /// <response code="200"><b>Ok:</b>
    /// <remarks>Motivos de Alta</remarks>
    /// </response>
    [SwaggerResponse(StatusCodes.Status200OK)]
    [HttpGet("MotivoAlta")]
    public async Task<List<GetMotivoAltaResponse>> getMotivoAlta([FromQuery] bool onlyActive)
    {
        return await _mediator.Send(new GetMotivoAlta(){ OnlyActive = onlyActive});
    }
    
    /// <summary>
    /// Catalogo Servicios
    /// </summary>
    /// <remarks>
    /// Devuelve una lista de los servicios ofrecidos por los fisioterapeutas
    /// <br/>
    /// <b>onlyActive:</b> Si no se devuelve ningun valor, por defecto sera <b>False</b>
    /// </remarks>
    /// <param name="onlyActive"><b>True: </b>solo devolvera a los activos, <b>False: </b> Devuelve todos los datos</param>
    /// <response code="200"><b>Ok:</b>
    /// <remarks>Servicios</remarks>
    /// </response>
    [SwaggerResponse(StatusCodes.Status200OK)]
    [HttpGet("Servicios")]
    public async Task<List<GetServiciosResponse>> getServicios([FromQuery] bool onlyActive)
    {
        return await _mediator.Send(new GetServicios(){ OnlyActive = onlyActive});
    }
    
    /// <summary>
    /// Catalogo de tipos de anticonceptivos
    /// </summary>
    /// <remarks>
    /// Devuelve una lista de los tipos de anticonceptivos
    /// <br/>
    /// <b>onlyActive:</b> Si no se devuelve ningun valor, por defecto sera <b>False</b>
    /// </remarks>
    /// <param name="onlyActive"><b>True: </b>solo devolvera a los activos, <b>False: </b> Devuelve todos los datos</param>
    /// <response code="200"><b>Ok:</b>
    /// <remarks>Tipo Anticonceptivo</remarks>
    /// </response>
    [SwaggerResponse(StatusCodes.Status200OK)]
    [HttpGet("TipoAnticonceptivo")]
    public async Task<List<GetAnticonceptivoResponse>> getAnticonceptivo([FromQuery] bool onlyActive)
    {
        return await _mediator.Send(new GetAnticonceptivo(){ OnlyActive = onlyActive});
    }
    
    /// <summary>
    /// Registrar una nueva especialidad
    /// </summary>
    /// <remarks>
    /// Catalogo de especialidades de los fisioterapeutas
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
    /// Registra un nuevo estado civil
    /// </summary>
    /// <remarks>
    /// Catalogo de estados civiles
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
    /// Registra un nuevo dato en flujo vaginal
    /// </summary>
    /// <remarks>
    /// Registra un nuevo dato en flujo vaginal
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
    /// Registra un nuevo dato en motivo alta
    /// </summary>
    /// <remarks>
    /// Posibles motivos de alta para los pacientes
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
    /// Registra un nuevo servicio
    /// </summary>
    /// <remarks>
    /// Servicios que los fisioterapeutas ofrecen
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
    /// Registra un nuevo tipo de anticonceptivo
    /// </summary>
    /// <remarks>
    /// Registra un nuevo tipo de anticonceptivo
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
    /// <remarks>
    /// No es necesario enviar todos los campos, solo los que se desean modificar
    /// <br/>
    /// <b>Descripcion</b>: Descripcion de la especialidad
    /// <br/>
    /// <b>Estatus</b>: Si quiere activar o desactivar la especialidad
    /// </remarks>
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
    /// <remarks>
    /// No es necesario enviar todos los campos, solo los que se desean modificar
    /// <br/>
    /// <b>Descripcion</b>: Descripcion de la especialidad
    /// <br/>
    /// <b>Estatus</b>: Si quiere activar o desactivar la especialidad
    /// </remarks>
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
    /// <remarks>
    /// No es necesario enviar todos los campos, solo los que se desean modificar
    /// <br/>
    /// <b>Descripcion</b>: Descripcion de la especialidad
    /// <br/>
    /// <b>Estatus</b>: Si quiere activar o desactivar la especialidad
    /// </remarks>
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
    /// <remarks>
    /// No es necesario enviar todos los campos, solo los que se desean modificar
    /// <br/>
    /// <b>Descripcion</b>: Descripcion de la especialidad
    /// <br/>
    /// <b>Estatus</b>: Si quiere activar o desactivar la especialidad
    /// </remarks>
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
    /// <remarks>
    /// No es necesario enviar todos los campos, solo los que se desean modificar
    /// <br/>
    /// <b>Descripcion</b>: Descripcion de la especialidad
    /// <br/>
    /// <b>Estatus</b>: Si quiere activar o desactivar la especialidad
    /// </remarks>
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
    /// <remarks>
    /// No es necesario enviar todos los campos, solo los que se desean modificar
    /// <br/>
    /// <b>Descripcion</b>: Descripcion de la especialidad
    /// <br/>
    /// <b>Estatus</b>: Si quiere activar o desactivar la especialidad
    /// </remarks>
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