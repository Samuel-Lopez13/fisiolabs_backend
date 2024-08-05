using System.ComponentModel.DataAnnotations;
using Core.Domain.Entities;
using Core.Domain.Helpers;
using Core.Infraestructure.Persistance;
using MediatR;

namespace Core.Features.Fisioterapeutas.command;

public record PostFisioterapeutas : IRequest
{
    [Required(ErrorMessage = "El campo Nombre es obligatorio")]
    public string Nombre { get; set; }
    
    [EmailAddress(ErrorMessage = "El campo Correo no es valido")]
    [Required(ErrorMessage = "El campo Correo es obligatorio")]
    public string Correo { get; set; }
    
    [Phone(ErrorMessage = "El campo Telefono no es valido")]
    [Required(ErrorMessage = "El campo Telefono es obligatorio")]
    public string Telefono { get; set; }
    
    public string? Cedula { get; set; }
    
    public string? Foto { get; set; }
    
    [Required(ErrorMessage = "El campo Especialidad es obligatorio")]
    public string EspecialidadId { get; set; }
}

public class PostFisioterapeutasHandler : IRequestHandler<PostFisioterapeutas>
{
    private readonly FisioContext _context;

    public PostFisioterapeutasHandler(FisioContext context)
    {
        _context = context;
    }
    
    public async Task Handle(PostFisioterapeutas request, CancellationToken cancellationToken)
    {
        var especialidad = await _context.Especialidades.FindAsync(request.EspecialidadId.HashIdInt());
        
        var fisio = new Fisioterapeuta() {
            Nombre = request.Nombre,
            Correo = request.Correo,
            Telefono = request.Telefono,
            CedulaProfesional = request.Cedula,
            Foto = request.Foto == null ? "https://res.cloudinary.com/doi0znv2t/image/upload/v1718432025/Utils/fotoPerfil.png" : request.Foto,
            Status = true, //Activo
            EspecialidadId = request.EspecialidadId.HashIdInt()
        };

        await _context.Fisioterapeuta.AddAsync(fisio);
        await _context.SaveChangesAsync();
    }
}