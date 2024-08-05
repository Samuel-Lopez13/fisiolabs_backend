using System.ComponentModel.DataAnnotations;
using Core.Domain.Entities;
using Core.Infraestructure.Persistance;
using MediatR;

namespace Core.Features.Catalogos.command;

public class PostEstadoCivil : IRequest
{
    [Required(ErrorMessage = "El campo Descripcion es obligatorio")]
    public string Descripcion { get; set; }
}

public class PostEstadoCivilHandler : IRequestHandler<PostEstadoCivil>
{
    private readonly FisioContext _context;
    
    public PostEstadoCivilHandler(FisioContext context)
    {
        _context = context;
    }
    
    public async Task Handle(PostEstadoCivil request, CancellationToken cancellationToken)
    {
        var estadoCivil = new Cat_EstadoCivil()
        {
            Descripcion = request.Descripcion,
            Status = true
        };
        
        await _context.EstadoCivils.AddAsync(estadoCivil);
        await _context.SaveChangesAsync();
    }
}