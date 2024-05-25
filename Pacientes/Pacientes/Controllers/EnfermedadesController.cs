using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pacientes.Entidades;

namespace Pacientes.Controllers
{
    [Route("api/enfermedades")]
    [ApiController]
    public class EnfermedadesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public EnfermedadesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var enfermedades = await context.Enfermedades.ToListAsync();

            if(enfermedades is null)
            {
                return BadRequest();
            }

            return Ok(enfermedades);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Enfermedad enfermedadesDto)
        {
            var existingEnfermedad = await context.Enfermedades.FirstOrDefaultAsync(e => e.nombre == enfermedadesDto.nombre);

            if (existingEnfermedad != null)
            {
                return BadRequest("La enfermedad ya existe en la base de datos.");
            }

            var nuevaEnfermedad = new Enfermedad
            {
                nombre = enfermedadesDto.nombre
            };

            context.Enfermedades.Add(nuevaEnfermedad);
            await context.SaveChangesAsync();
            return Ok(nuevaEnfermedad);
        }
    }
}
