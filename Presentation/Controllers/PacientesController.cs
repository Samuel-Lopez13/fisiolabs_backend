using Core.Features.Pacientes.Command;
using Core.Features.Pacientes.queries;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

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

    [HttpGet("Pacientes")]
    public async Task<List<PacientesResponse>> getPacientes([FromQuery] int pagina)
    {
        return await _mediator.Send(new Pacientes() { Pagina = pagina });
    }
    
    [HttpGet("paginas")]
    public async Task<NumeroPaginasResponse> getPaginas()
    {
        return await _mediator.Send(new NumeroPaginas());
    }
    
    [HttpGet("UltimosPacientes")]
    public async Task<List<UltimosPacientesResponse>> getUltimosPacientes()
    {
        return await _mediator.Send(new UltimosPacientes());
    }
    
    [HttpPost("CrearPaciente")]
    [EnableCors("AllowSpecificOrigin")]
    public async Task<IActionResult> PostPaciente([FromForm] CrearPaciente command)
    {
        await _mediator.Send(command);
        return Ok("El paciente se registro correctamente");
    }
}