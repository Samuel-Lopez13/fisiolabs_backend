using Core.Domain.Exceptions;
using Core.Domain.Helpers;
using Core.Infraestructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Diagnostico.queries;

public record DiagnosticGet : IRequest<GeneralDiagnosticResponse>
{
    public string DiagnosticoId { get; set; }
}

public record DiagnosticGetHandler : IRequestHandler<DiagnosticGet, GeneralDiagnosticResponse>
{
    private readonly FisiolabsSofwaredbContext _context;
    
    public DiagnosticGetHandler(FisiolabsSofwaredbContext context)
    {
        _context = context;
    }
    
    public async Task<GeneralDiagnosticResponse> Handle(DiagnosticGet request, CancellationToken cancellationToken)
    {
        var diagnostic = await _context.Diagnosticos
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.DiagnosticoId == request.DiagnosticoId.HashIdInt());
        
        if(diagnostic == null)
            throw new NotFoundException("No se encontro el diagnostico");
        
        //Buscamos sus datos
        var programa = await _context.ProgramaFisioterapeuticos
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.DiagnosticoId == diagnostic.DiagnosticoId);
        
        var mapa = await _context.MapaCorporals
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.DiagnosticoId == diagnostic.DiagnosticoId);
        
        var exploracion = await _context.ExploracionFisicas
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.DiagnosticoId == diagnostic.DiagnosticoId);
        
        return await Task.FromResult(new GeneralDiagnosticResponse
        {
            Diagnostico = diagnostic.Diagnostico1,
            diagnostic = new GetDiagnostic
            {
                Diagnostico = diagnostic.Diagnostico1,
                Refiere = diagnostic.Refiere,
                Categoria = diagnostic.Categoria,
                DiagnosticoPrevio = diagnostic.DiagnosticoPrevio,
                TerapeuticaEmpleada = diagnostic.TerapeuticaEmpleada,
                DiagnosticoFuncional = diagnostic.DiagnosticoFuncional,
                PadecimientoActual = diagnostic.PadecimientoActual,
                Inspeccion = diagnostic.Inspeccion,
                Palpitacion = diagnostic.Palpitacion,
                Movibilidad = diagnostic.Movibilidad,
                EstudiosComplementarios = diagnostic.EstudiosComplementarios,
                DiagnosticoNosologico = diagnostic.DiagnosticoNosologico,
                FechaInicio = diagnostic.FechaInicio,
                FechaAlta = diagnostic.FechaAlta,
                MotivoAlta = diagnostic.MotivoAlta,
                DiagnosticoInicial = diagnostic.DiagnosticoInicial,
                DiagnosticoFinal = diagnostic.DiagnosticoFinal,
                FrecuenciaTratamiento = diagnostic.FrecuenciaTratamiento
            },
            program = new ProgramGet
            {
                CortoPlazo = programa.CortoPlazo,
                MedianoPlazo = programa.MedianoPlazo,
                LargoPlazo = programa.LargoPlazo,
                TratamientoFisioterapeutico = programa.TratamientoFisioterapeutico,
                Sugerencias = programa.Sugerencias,
                Pronostico = programa.Pronostico
            },
            map = new MapGet
            {
                valores = mapa.ValorX,
                RangoDolor = mapa.RangoDolor,
                Nota = mapa.Nota
            },
            exploration = new ExplorationGet
            {
                Temperatura = exploracion.Temperatura,
                Fr = exploracion.Fr,
                Fc = exploracion.Fc,
                PresionArterial = exploracion.PresionArterial,
                Peso = exploracion.Peso,
                Estatura = exploracion.Estatura,
                Imc = exploracion.Imc,
                IndiceCinturaCadera = exploracion.IndiceCinturaCadera,
                SaturacionOxigeno = exploracion.SaturacionOxigeno
            }
        });
    }
}

public record GeneralDiagnosticResponse
{
    public string Diagnostico { get; set; }
    
    public GetDiagnostic diagnostic { get; set; }
    public ProgramGet program { get; set; }
    public MapGet map { get; set; }
    public ExplorationGet exploration { get; set; }
}

public record GetDiagnostic()
{
    public string Diagnostico { get; set; }
    
    public string Refiere { get; set; }
    
    public string Categoria { get; set; }
    
    public string DiagnosticoPrevio { get; set; }
    
    public string TerapeuticaEmpleada { get; set; }
    
    public string DiagnosticoFuncional { get; set; }
    
    public string PadecimientoActual { get; set; }
    
    public string Inspeccion { get; set; }
    
    public string Palpitacion { get; set; }
    
    public string Movibilidad { get; set; }
    
    public string EstudiosComplementarios { get; set; }
    
    public string DiagnosticoNosologico { get; set; }
    
    public DateTime FechaInicio { get; set; }

    public DateTime? FechaAlta { get; set; }

    public string? MotivoAlta { get; set; }
    
    public string? DiagnosticoInicial { get; set; }

    public string? DiagnosticoFinal { get; set; }

    public string? FrecuenciaTratamiento { get; set; }
}

public record ProgramGet()
{
    public string CortoPlazo { get; set; }
    
    public string MedianoPlazo { get; set; }
    
    public string LargoPlazo { get; set; }
    
    public string TratamientoFisioterapeutico { get; set; }
    
    public string Sugerencias { get; set; }
    
    public string Pronostico { get; set; }
}

public record MapGet()
{
    public List<int> valores { get; set; }
    
    public List<int> RangoDolor { get; set; }
    
    public string Nota { get; set; }
}

public record ExplorationGet()
{
    public float? Temperatura { get; set; }
    
    public int? Fr { get; set; }
    
    public int? Fc { get; set; }
    
    public string PresionArterial { get; set; }
    
    public float? Peso { get; set; }
    
    public float? Estatura { get; set; }
    
    public float? Imc { get; set; }
    
    public float? IndiceCinturaCadera { get; set; }
    
    public float? SaturacionOxigeno { get; set; }
}