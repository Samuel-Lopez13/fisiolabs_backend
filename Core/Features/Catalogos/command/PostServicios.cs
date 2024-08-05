using System.ComponentModel.DataAnnotations;
using Core.Domain.Entities;
using Core.Infraestructure.Persistance;
using MediatR;

namespace Core.Features.Catalogos.command;

public class PostServicios : IRequest
{
    [Required(ErrorMessage = "El campo Descripcion es obligatorio")]
    public string Descripcion { get; set; }
}

public class PostServiciosHandler : IRequestHandler<PostServicios>
{
    private readonly FisioContext _context;
    
    public PostServiciosHandler(FisioContext context)
    {
        _context = context;
    }
    
    public async Task Handle(PostServicios request, CancellationToken cancellationToken)
    {
        var servicios = new Cat_Servicios()
        {
            Descripcion = request.Descripcion,
            Status = true
        };
        
        await _context.Servicios.AddAsync(servicios);
        await _context.SaveChangesAsync();
    }
}