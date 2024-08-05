using System.ComponentModel.DataAnnotations;
using Core.Domain.Entities;
using Core.Domain.Exceptions;
using Core.Domain.Helpers;
using Core.Infraestructure.Persistance;
using MediatR;

namespace Core.Features.Diagnostico.command;

public record ExplorationPost()
{
    [Required(ErrorMessage = "El campo Temperatura es obligatorio")]
    public float Temperatura { get; set; }
    
    [Required(ErrorMessage = "El campo Fr es obligatorio")]
    public int Fr { get; set; }
    
    [Required(ErrorMessage = "El campo Fc es obligatorio")]
    public int Fc { get; set; }
    
    [Required(ErrorMessage = "El campo PresionArterial es obligatorio")]
    public string PresionArterial { get; set; }
    
    [Required(ErrorMessage = "El campo Peso es obligatorio")]
    public float Peso { get; set; }
    
    [Required(ErrorMessage = "El campo Estatura es obligatorio")]
    public float Estatura { get; set; }
    
    [Required(ErrorMessage = "El campo Imc es obligatorio")]
    public float Imc { get; set; }
    
    [Required(ErrorMessage = "El campo IndiceCinturaCadera es obligatorio")]
    public float IndiceCinturaCadera { get; set; }
    
    [Required(ErrorMessage = "El campo SaturacionOxigeno es obligatorio")]
    public float SaturacionOxigeno { get; set; }
}

public record MapPost()
{
    [Required(ErrorMessage = "El campo valores es obligatorio")]
    public List<int> valores { get; set; }
    
    [Required(ErrorMessage = "El campo RangoDolor es obligatorio")]
    public List<int> RangoDolor { get; set; }
    
    [Required(ErrorMessage = "El campo Nota es obligatorio")]
    public string Nota { get; set; }
}

public record PostDiagnostic()
{
    [Required(ErrorMessage = "El campo Diagnostico es obligatorio")]
    public string Diagnostico { get; set; }
    
    [Required(ErrorMessage = "El campo Refiere es obligatorio")]
    public string Refiere { get; set; }
    
    [Required(ErrorMessage = "El campo Categoria es obligatorio")]
    public string Categoria { get; set; }
    
    [Required(ErrorMessage = "El campo DiagnosticoPrevio es obligatorio")]
    public string DiagnosticoPrevio { get; set; }
    
    [Required(ErrorMessage = "El campo TerapeuticaEmpleada es obligatorio")]
    public string TerapeuticaEmpleada { get; set; }
    
    [Required(ErrorMessage = "El campo DiagnosticoFuncional es obligatorio")]
    public string DiagnosticoFuncional { get; set; }
    
    [Required(ErrorMessage = "El campo PadecimientoActual es obligatorio")]
    public string PadecimientoActual { get; set; }
    
    [Required(ErrorMessage = "El campo Inspeccion es obligatorio")]
    public string Inspeccion { get; set; }
    
    [Required(ErrorMessage = "El campo Palpitacion es obligatorio")]
    public string Palpitacion { get; set; }
    
    [Required(ErrorMessage = "El campo Movibilidad es obligatorio")]
    public string Movibilidad { get; set; }
    
    [Required(ErrorMessage = "El campo EstudiosComplementarios es obligatorio")]
    public string EstudiosComplementarios { get; set; }
    
    [Required(ErrorMessage = "El campo DiagnosticoNosologico es obligatorio")]
    public string DiagnosticoNosologico { get; set; }
}

public record ProgramPost()
{
    [Required(ErrorMessage = "El campo CortoPlazo es obligatorio")]
    public string CortoPlazo { get; set; }
    
    [Required(ErrorMessage = "El campo MedianoPlazo es obligatorio")]
    public string MedianoPlazo { get; set; }
    
    [Required(ErrorMessage = "El campo LargoPlazo es obligatorio")]
    public string LargoPlazo { get; set; }
    
    [Required(ErrorMessage = "El campo TratamientoFisioterapeutico es obligatorio")]
    public string TratamientoFisioterapeutico { get; set; }
    
    [Required(ErrorMessage = "El campo Sugerencias es obligatorio")]
    public string Sugerencias { get; set; }
    
    [Required(ErrorMessage = "El campo Pronostico es obligatorio")]
    public string Pronostico { get; set; }
}

public record ReviewPost()
{
    [Required(ErrorMessage = "El campo ComprobantePago es obligatorio")]
    public string ComprobantePago { get; set; }
}

public record GeneralDiagnosticPost() : IRequest
{
    public string ExpedienteId { get; set; }
    public ExplorationPost Exploration { get; set; }
    public MapPost Map { get; set; }
    public PostDiagnostic Diagnostic { get; set; }
    public ProgramPost Program { get; set; }
    public ReviewPost Review { get; set; }
}

public class PostDiagnosticHanlder : IRequestHandler<GeneralDiagnosticPost>
{
    private readonly FisioContext _context;

    public PostDiagnosticHanlder(FisioContext context)
    {
        _context = context;
    }
    
    public async Task Handle(GeneralDiagnosticPost request, CancellationToken cancellationToken)
    {
        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                /* Creamos primero el diagnostico */
                var diagnostico = new Domain.Entities.Diagnostico()
                {
                    FechaInicio = FormatDate.DateLocal(),
                    Estatus = true,
                    Categoria = request.Diagnostic.Categoria,
                    DiagnosticoPrevio = request.Diagnostic.DiagnosticoPrevio,
                    DiagnosticoFuncional = request.Diagnostic.DiagnosticoFuncional,
                    Descripcion = request.Diagnostic.Diagnostico,
                    PadecimientoActual = request.Diagnostic.PadecimientoActual,
                    Refiere = request.Diagnostic.Refiere,
                    TerapeuticaEmpleada = request.Diagnostic.TerapeuticaEmpleada,
                    Inspeccion = request.Diagnostic.Inspeccion,
                    Palpitacion = request.Diagnostic.Palpitacion,
                    Movibilidad = request.Diagnostic.Movibilidad,
                    EstudiosComplementarios = request.Diagnostic.EstudiosComplementarios,
                    DiagnosticoNosologico = request.Diagnostic.DiagnosticoNosologico,
                    ExpedienteId = request.ExpedienteId.HashIdInt()
                };
                
                await _context.Diagnosticos.AddAsync(diagnostico);
                await _context.SaveChangesAsync();
                
                /* Creamos la exploracion Fisica */
                var exploracion = new ExploracionFisica()
                {
                    Temperatura = request.Exploration.Temperatura,
                    Fr = request.Exploration.Fr,
                    Fc = request.Exploration.Fc,
                    PresionArterial = request.Exploration.PresionArterial,
                    Peso = request.Exploration.Peso,
                    Estatura = request.Exploration.Estatura,
                    Imc = request.Exploration.Imc,
                    IndiceCinturaCadera = request.Exploration.IndiceCinturaCadera,
                    SaturacionOxigeno = request.Exploration.SaturacionOxigeno
                };
                
                await _context.ExploracionFisicas.AddAsync(exploracion);
                await _context.SaveChangesAsync();
                
                var program = new ProgramaFisioterapeutico()
                {
                    CortoPlazo = request.Program.CortoPlazo,
                    MedianoPlazo = request.Program.MedianoPlazo,
                    LargoPlazo = request.Program.LargoPlazo,
                    TratamientoFisioterapeutico = request.Program.TratamientoFisioterapeutico,
                    Sugerencias = request.Program.Sugerencias,
                    Pronostico = request.Program.Pronostico
                };
                
                await _context.ProgramaFisioterapeuticos.AddAsync(program);
                await _context.SaveChangesAsync();

                var mapa = new MapaCorporal()
                {
                    Valor = request.Map.valores,
                    RangoDolor = request.Map.RangoDolor,
                    Nota = request.Map.Nota,
                };
                
                await _context.MapaCorporals.AddAsync(mapa);
                await _context.SaveChangesAsync();

                var revision = new Revision()
                {
                    Notas = request.Map.Nota,
                    FolioPago = request.Review.ComprobantePago,
                    Fecha = FormatDate.DateLocal(),
                    Hora =  new TimeSpan(FormatDate.DateLocal().Hour, FormatDate.DateLocal().Minute, 0),
                    DiagnosticoId = diagnostico.DiagnosticoId
                };
                
                await _context.Revisions.AddAsync(revision);
                await _context.SaveChangesAsync();
                
                //Si todo sale bien commitiar 
                transaction.Commit();
            }
            catch (Exception ex)
            {
                // Si ocurre un error, revertir la transacción
                try
                {
                    transaction.Rollback();
                }
                catch (Exception exRollback)
                {
                    Console.WriteLine("Error al revertir la transacción: " + exRollback.Message);
                }
                
                throw new BadRequestException("Error al procesar los datos");
            }
        }
    }
}