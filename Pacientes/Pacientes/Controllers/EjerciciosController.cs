using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pacientes.Entidades;

namespace Pacientes.Controllers
{
    [Route("api/ejercicios")]
    [ApiController]
    public class EjerciciosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public EjerciciosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var ejercicios = await context.Ejercicios.ToListAsync();

            if(ejercicios is null)
            {
                return BadRequest();
            }

            return Ok(ejercicios);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Ejercicios ejercicioDto)
        {
            var existingEjercicio = await context.Ejercicios.FirstOrDefaultAsync(e => e.nombre == ejercicioDto.nombre);

            if(existingEjercicio != null)
            {
                return BadRequest("El ejercicio ya existe en la base de datos.");
            }

            var nuevoEjercicio = new Ejercicios
            {
                nombre = ejercicioDto.nombre
            };

            context.Ejercicios.Add(nuevoEjercicio);
            await context.SaveChangesAsync();
            return Ok(nuevoEjercicio);
        }
    }
}
