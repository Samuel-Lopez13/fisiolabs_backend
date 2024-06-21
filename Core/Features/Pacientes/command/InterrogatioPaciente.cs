using System.ComponentModel.DataAnnotations;
using Core.Domain.Entities;
using Core.Domain.Exceptions;
using Core.Infraestructure.Persistance;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Core.Features.Pacientes.Command;

public record HeredoFamilia
{
    [Required]
    public int Padres { get; set; }

    [Required]
    public int PadresVivos { get; set; }

    public string? PadresCausaMuerte { get; set; }

    [Required]
    public int Hermanos { get; set; }

    [Required]
    public int HermanosVivos { get; set; }

    public string? HermanosCausaMuerte { get; set; }

    [Required]
    public int Hijos { get; set; }

    [Required]
    public int HijosVivos { get; set; }

    public string? HijosCausaMuerte { get; set; }

    public string? Dm { get; set; }

    public string? Hta { get; set; }

    public string? Cancer { get; set; }

    public string? Alcoholismo { get; set; }

    public string? Tabaquismo { get; set; }

    public string? Drogas { get; set; }
}

public record Antecedentes
{
    public string AntecedentesPatologicos { get; set; }

    public string MedioLaboral { get; set; }

    public string MedioSociocultural { get; set; }

    public string MedioFisicoambiental { get; set; }
}

public record Ginecobstetrico
{
    public string? Fum { get; set; }

    public string? Fpp { get; set; }

    public int? EdadGestional { get; set; }

    public int? Semanas { get; set; }

    public string? Menarca { get; set; }

    public string? Ritmo { get; set; }

    public int? Gestas { get; set; }

    public int? Partos { get; set; }

    public int? Cesareas { get; set; }

    public int? Abortos { get; set; }

    public string? Cirugias { get; set; }

    public int? FlujoVaginalId { get; set; }

    public int? TipoAnticonceptivoId { get; set; }
}

public record InterrogatioPaciente : IRequest
{
    [Required]
    public int PacienteId { get; set; }
    
    [Required]
    public bool TipoInterrogatorio { get; set; }
    
    public string? Responsable { get; set; }
    
    public HeredoFamilia HeredoFamiliar { get; set; }
    public Antecedentes Antecedente { get; set; }
    public Ginecobstetrico? Ginecobstetricos { get; set; }
};

public class InterrogatioPacienteHandler : IRequestHandler<InterrogatioPaciente>
{
    private readonly FisiolabsSofwaredbContext _context;

    public InterrogatioPacienteHandler(FisiolabsSofwaredbContext context)
    {
        _context = context;
    }

    public async Task Handle(InterrogatioPaciente request, CancellationToken cancellationToken)
    {
        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                /* Creamos primero el expediente */
                var expediente = new Expediente()
                {
                    TipoInterrogatorio = request.TipoInterrogatorio,
                    Responsable = request.Responsable,
                    AntecedentesPatologicos = request.Antecedente.AntecedentesPatologicos,
                    PacienteId = request.PacienteId
                };

                await _context.Expedientes.AddAsync(expediente);
                await _context.SaveChangesAsync();

                /* Creamos los datos no Patologicos */
                var noPatologico = new NoPatologico()
                {
                    MedioLaboral = request.Antecedente.MedioLaboral,
                    MedioSociocultural = request.Antecedente.MedioSociocultural,
                    MedioFisicoambiental = request.Antecedente.MedioFisicoambiental,
                    ExpededienteId = expediente.ExpedienteId,
                };

                await _context.NoPatologicos.AddAsync(noPatologico);
                await _context.SaveChangesAsync();

                var heredoFamiliar = new HeredoFamiliar()
                {
                    Padres = request.HeredoFamiliar.Padres,
                    PadresVivos = request.HeredoFamiliar.PadresVivos,
                    PadresCausaMuerte = request.HeredoFamiliar.PadresCausaMuerte,
                    Hermanos = request.HeredoFamiliar.Hermanos,
                    HermanosVivos = request.HeredoFamiliar.HermanosVivos,
                    HermanosCausaMuerte = request.HeredoFamiliar.HermanosCausaMuerte,
                    Hijos = request.HeredoFamiliar.Hijos,
                    HijosVivos = request.HeredoFamiliar.HijosVivos,
                    HijosCausaMuerte = request.HeredoFamiliar.HijosCausaMuerte,
                    Dm = request.HeredoFamiliar.Dm,
                    Hta = request.HeredoFamiliar.Hta,
                    Cancer = request.HeredoFamiliar.Cancer,
                    Alcoholismo = request.HeredoFamiliar.Alcoholismo,
                    Tabaquismo = request.HeredoFamiliar.Tabaquismo,
                    Drogas = request.HeredoFamiliar.Drogas,
                    ExpededienteId = expediente.ExpedienteId
                };
                
                await _context.HeredoFamiliars.AddAsync(heredoFamiliar);
                await _context.SaveChangesAsync();
                
                var paciente = await _context.Pacientes.FindAsync(request.PacienteId);

                if (paciente.Sexo == false)
                {
                    var ginecobtetrico = new GinecoObstetrico()
                    {
                        Fum = request.Ginecobstetricos.Fum,
                        Fpp = request.Ginecobstetricos.Fpp,
                        EdadGestional = request.Ginecobstetricos.EdadGestional,
                        Semanas = request.Ginecobstetricos.Semanas,
                        Menarca = request.Ginecobstetricos.Menarca,
                        Ritmo = request.Ginecobstetricos.Ritmo,
                        Gestas = request.Ginecobstetricos.Gestas,
                        Partos = request.Ginecobstetricos.Partos,
                        Cesareas = request.Ginecobstetricos.Cesareas,
                        Abortos = request.Ginecobstetricos.Abortos,
                        Cirugias = request.Ginecobstetricos.Cirugias,
                        FlujoVaginalId = request.Ginecobstetricos.FlujoVaginalId,
                        TipoAnticonceptivoId = request.Ginecobstetricos.TipoAnticonceptivoId,
                        ExpededienteId = expediente.ExpedienteId
                    };
                    
                    await _context.GinecoObstetricos.AddAsync(ginecobtetrico);
                    await _context.SaveChangesAsync();
                }
                
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