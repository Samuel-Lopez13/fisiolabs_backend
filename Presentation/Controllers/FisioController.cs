using Core.Features;
using Core.Features.Citas.queries;
using Core.Features.Fisioterapeutas.command;
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
public class FisioController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public FisioController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    /// <summary>
    /// Obtiene todos los fisioterapeutas
    /// </summary>
    /// <remarks>
    /// Devuelve una lista con informacion de los fisioterapeutas
    /// <br/>
    /// <b>onlyActive:</b> Si no se devuelve ningun valor, por defecto sera <b>False</b>
    /// </remarks>
    /// <param name="onlyActive"><b>True: </b>solo devolvera a los activos, <b>False: </b> Devuelve todos los datos</param>
    /// <response code="200"><b>Ok:</b>
    /// <remarks>Fisioterapeutas</remarks>
    /// </response>
    [SwaggerResponse(StatusCodes.Status200OK)]
    [HttpGet()]
    public async Task<List<GetFisioterapeutaResponse>> GetFisio([FromQuery] bool onlyActive)
    {
        return await _mediator.Send(new GetFisioterapeutas(){ OnlyActive = onlyActive});
    }
    
    /// <summary>
    /// Registrar a un nuevo fisioterapeuta
    /// </summary>
    /// <remarks>
    /// Registra a un nuevo fisioterapeuta
    /// <br/>
    /// <b>Telefono:</b> El telefono debe de contener un formato valido
    /// </remarks>
    /// <response code="200"><b>Ok:</b>
    /// <remarks>Se creo exitosamente el fisioterapeuta</remarks>
    /// </response>
    /// <response code="400"><b>Bad Request:</b>
    /// <remarks>Algun dato se lleno incorrectamente</remarks>
    /// </response>
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Hubo algun fallo en el registro", typeof(ErrorResponse))]
    [HttpPost()]
    public async Task<IActionResult> PostFisio([FromBody] PostFisioterapeutas command)
    {
        await _mediator.Send(command);
        return Ok("Se creo el fisioterapeuta correctamente");
    }
}