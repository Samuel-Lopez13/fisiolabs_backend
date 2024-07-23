using Core.Features.Diagnostico.command;
using Core.Features.Diagnostico.queries;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[ApiController]
[Route("[controller]")]
public class DiagnosticoController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public DiagnosticoController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet()]
    public async Task<GeneralDiagnosticResponse> DiagnosticGet([FromQuery] string diagnostico)
    {
        return await _mediator.Send(new DiagnosticGet() { DiagnosticoId = diagnostico });
    }
    
    [HttpGet("Activo")]
    public async Task<DiagnosticActiveResponse> ActiveDiagnostic([FromQuery] string expediente)
    {
        return await _mediator.Send(new DiagnosticActive() { ExpedienteId = expediente });
    }
    
    [HttpGet("Revision")]
    public async Task<List<GetRevisionesResponse>> GetReview([FromQuery] string diagnostico)
    {
        return await _mediator.Send(new GetRevisiones() { DiagnosticoId = diagnostico });
    }
    
    [HttpPost()]
    public async Task<IActionResult> PostDiagnostic([FromBody] GeneralDiagnosticPost command)
    {
        await _mediator.Send(command);
        return Ok("Se creo el diagnostico correctamente");
    }
    
    [HttpPost("Revision")]
    public async Task<IActionResult> PostReview([FromBody] PostRevisiones command)
    {
        await _mediator.Send(command);
        return Ok("Se creo la revision correctamente");
    }
}