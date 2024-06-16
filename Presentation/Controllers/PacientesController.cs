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
    private readonly IWebHostEnvironment _environment;
    private readonly IUploadFile _uploadFile;
    public PacientesController(IMediator mediator, IWebHostEnvironment environment, IUploadFile uploadFile)
    {
        _mediator = mediator;
        _environment = environment;
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
        if (file == null || file.Length == 0)
            return BadRequest("No se ha subido ningún archivo.");

        /*var uploadsFolder = Path.Combine(_environment.ContentRootPath, "wwwroot", "uploads");
        if (!Directory.Exists(uploadsFolder))
        {
            Directory.CreateDirectory(uploadsFolder);
        }

        var filePath = Path.Combine(uploadsFolder, file.FileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        var relativePath = Path.Combine("uploads", file.FileName);*/
        var fotoPerfil = _uploadFile.UploadImages(file, ": Paciente");
        return Ok(new { message = "Imagen subida correctamente", path = fotoPerfil });
    }
}