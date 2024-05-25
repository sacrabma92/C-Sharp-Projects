using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pacientes.DTO;
using Pacientes.Entidades;
using System.Runtime.ConstrainedExecution;

namespace Pacientes.Controllers
{
    [Route("api/paciente")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public PacienteController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<PacienteMuestraDto>> Get()
        {
            var pacientes = await context.Pacientes
                .Include(p => p.Imc)
                .Include(p => p.PacientePeso)
                .ToListAsync();

            var pacientesUnicos = pacientes.DistinctBy(p => p.Id).ToList();

            var pacientesDto = pacientesUnicos.Select(p => new PacienteMuestraDto
            {
                cedula = p.cedula,
                nombre = p.nombre,
                genero = p.genero,
                fechanac = p.fechanac,
                Imc = p.Imc.Select(i => new ImcDto
                {
                    peso = i.peso,
                    altura = i.altura,
                    totalimc = i.totalimc
                }).ToList()
            }).ToList();

            return Ok(pacientesDto);
        }


        [HttpGet("muestra/{ced}")]
        public async Task<ActionResult<Paciente>> GetPaciente(string ced)
        {
            var paciente = await context.Pacientes
                .Include(p => p.Imc)
                .Include(p => p.PacientePeso)
                .FirstOrDefaultAsync(g => g.cedula == ced);

            if(paciente == null)
            {
                return BadRequest();
            }

            return paciente;
        }

        [HttpGet("existe/{ced}")]
        public async Task<ActionResult<Paciente>> cedula(string ced)
        {
            var cedu = await context.Pacientes.FirstOrDefaultAsync(g => g.cedula == ced);

            if (cedu == null)
            {
                return NotFound(new { mensaje = "No se encontró la cédula." });
            }

            return Ok(new { mensaje = "La cédula existe." });
        }

        [HttpPost]
        public async Task<ActionResult<PacienteCreacionDto>> Post(PacienteCreacionDto pacie)
        {
            // Verificar si ya existe un paciente con el mismo número de cédula
            var existingPatient = await context.Pacientes.FirstOrDefaultAsync(p => p.cedula == pacie.cedula);
            if (existingPatient != null)
            {
                // Si ya existe un paciente con la misma cédula, devolver un resultado BadRequest
                return BadRequest("Ya existe un paciente con el mismo número de cédula.");
            }

            var paciente = new Paciente()
            {
                cedula = pacie.cedula,
                nombre = pacie.nombre,
                genero = pacie.genero,
                fechanac = pacie.fechanac,
                // Inicializar la lista de Imc
                Imc = new List<Imc>(),
                PacientePeso = new List<PacientePeso>()
            };

            var imc = new Imc()
            {
                peso = pacie.Imc.peso,
                altura = pacie.Imc.altura,
                totalimc = pacie.Imc.totalimc
            };

            var existDieta = await context.Dietas.FirstOrDefaultAsync(p => p.Id == pacie.PacientePeso.DietaId);
            if (existDieta is null)
            {
                // Si no existe una dieta
                return NotFound(new { mensaje = "La dieta no existe" });
            }

            foreach (var ejercicioId in pacie.PacientePeso.EjerciciosId)
            {
                var pacientepeso = new PacientePeso()
                {
                    DietaId = pacie.PacientePeso.DietaId,
                    EjerciciosId = ejercicioId,
                    PacienteId = paciente.Id
                };

                var existeEjercicio = await context.Ejercicios.FirstOrDefaultAsync(p => p.Id == ejercicioId);
                if (existeEjercicio is null)
                {
                    // Si no existe el ejercicio
                    return NotFound(new { mensaje = $"El ejercicio con ID {ejercicioId} no existe" });
                }

                paciente.PacientePeso.Add(pacientepeso);
            }

            paciente.Imc.Add(imc);

            context.Add(paciente);
            await context.SaveChangesAsync();
            return Ok();
        }


    }
}
