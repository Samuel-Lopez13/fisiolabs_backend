using System.ComponentModel.DataAnnotations;
using Core.Domain.Entities;
using Core.Infraestructure.Persistance;
using MediatR;

namespace Core.Features.Catalogos.command;

public class PostMotivoAlta : IRequest
{
    [Required(ErrorMessage = "El campo Descripcion es obligatorio")]
    public string Descripcion { get; set; }
}

public class PostMotivoAltaHandler : IRequestHandler<PostMotivoAlta>
{
    private readonly FisioContext _context;
    
    public PostMotivoAltaHandler(FisioContext context)
    {
        _context = context;
    }
    
    public async Task Handle(PostMotivoAlta request, CancellationToken cancellationToken)
    {
        var alta = new Cat_MotivoAlta()
        {
            Descripcion = request.Descripcion,
            Status = true
        };
        
        await _context.MotivoAltas.AddAsync(alta);
        await _context.SaveChangesAsync();
    }
}