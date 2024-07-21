using Core.Features.Diagnostico.command;
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
    
    [HttpPost()]
    public async Task<IActionResult> PostDiagnostic([FromBody] GeneralDiagnosticPost command)
    {
        await _mediator.Send(command);
        return Ok("Se creo el diagnostico correctamente");
    }
}