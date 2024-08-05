using System.ComponentModel.DataAnnotations;
using Core.Domain.Entities;
using Core.Infraestructure.Persistance;
using MediatR;

namespace Core.Features.Catalogos.command;

public class PostEspecialidades : IRequest
{
    [Required(ErrorMessage = "El campo Descripcion es obligatorio")]
    public string Descripcion { get; set; }
}

public class PostEspecialidadesHandler : IRequestHandler<PostEspecialidades>
{
    private readonly FisioContext _context;
    
    public PostEspecialidadesHandler(FisioContext context)
    {
        _context = context;
    }
    
    public async Task Handle(PostEspecialidades request, CancellationToken cancellationToken)
    {
        var especialidades = new Cat_Especialidades()
        {
            Descripcion = request.Descripcion,
            Status = true
        };
        
        await _context.Especialidades.AddAsync(especialidades);
        await _context.SaveChangesAsync();
    }
}