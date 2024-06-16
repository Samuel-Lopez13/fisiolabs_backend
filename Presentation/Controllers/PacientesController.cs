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
    private readonly IUploadFile _uploadFile;
    
    public PacientesController(IMediator mediator, IUploadFile uploadFile)
    {
        _mediator = mediator;
        _uploadFile = uploadFile;
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
    public async Task<IActionResult> PostPaciente([FromForm] CrearPaciente command)
    {
        await _mediator.Send(command);
        return Ok("El paciente se registro correctamente");
    }
    
    [HttpPost]
    [Route("upload")]
    public async Task<IActionResult> UploadImage(IFormFile file)
    {
        string fotoPerfil = _uploadFile.UploadImages(file, ": Paciente");
        Console.WriteLine(fotoPerfil);
        return Ok(new { message = "Imagen subida correctamente" });
    }
}