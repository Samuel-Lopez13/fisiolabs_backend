using Core.Domain.Exceptions;
using Core.Domain.Services;
using Core.Features.Pacientes.Command;
using Core.Features.Pacientes.queries;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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

    [HttpGet()]
    public async Task<List<PacientesResponse>> getPacientes([FromQuery] int pagina)
    {
        return await _mediator.Send(new Pacientes() { Pagina = pagina });
    }
    
    [HttpGet("Paciente")]
    public async Task<PacienteResponse> getPaciente([FromQuery] int id)
    {
        return await _mediator.Send(new Paciente(){ PacienteId = id});
    }
    
    [HttpGet("Buscador")]
    public async Task<BuscarPacienteResponse> getBuscador([FromQuery] int pagina, [FromQuery] string nombre)
    {
        return await _mediator.Send(new BuscarPaciente() { Pagina = pagina, Nombre = nombre});
    }

    [HttpGet("Datos")]
    public async Task<DatosPacienteResponse> getDatos([FromQuery] int paciente)
    {
        return await _mediator.Send(new DatosPaciente() { PacienteId = paciente });
    }
    
    [HttpGet("paginas")]
    public async Task<NumeroPaginasResponse> getPaginas()
    {
        return await _mediator.Send(new NumeroPaginas());
    }
    
    [HttpGet("UltimosRegistrados")]
    public async Task<List<UltimosPacientesResponse>> getUltimosPacientes()
    {
        return await _mediator.Send(new UltimosPacientes());
    }
    
    [HttpPost()]
    public async Task<CrearPacienteResponse> PostPaciente([FromBody] CrearPaciente command)
    {
        return await _mediator.Send(command);
    }
    
    [HttpPost("Interrogatorio")]
    public async Task<IActionResult> PostInterrogatorio([FromBody] InterrogatioPaciente command)
    {
        await _mediator.Send(command);
        return Ok("Se agregaron los datos correctamente");
    }
}