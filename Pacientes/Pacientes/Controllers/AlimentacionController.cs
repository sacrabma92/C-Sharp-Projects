using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pacientes.Entidades;

namespace Pacientes.Controllers
{
    [Route("api/alimentacion")]
    [ApiController]
    public class AlimentacionController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public AlimentacionController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<List<Alimentacion>> get()
        {
            return await context.Alimentaciones.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Alimentacion alimentacionDto)
        {
            var existingAlimentacion = await context.Alimentaciones.FirstOrDefaultAsync(e => e.nombre == alimentacionDto.nombre);

            if (existingAlimentacion != null)
            {
                return BadRequest("El alimento ya existe en la base de datos.");
            }

            var nuevoAlimento = new Alimentacion
            {
                nombre = alimentacionDto.nombre
            };

            context.Alimentaciones.Add(nuevoAlimento);
            await context.SaveChangesAsync();
            return Ok(nuevoAlimento);
        }

    }
}