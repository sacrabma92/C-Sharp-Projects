using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Peliculas.Entities;

namespace Peliculas.Controllers
{
    [Route("api/generos")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public GenerosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Genero>> Get()
        {
            return await context.Generos.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Genero>> Get(int id)
        {
            var genero = await context.Generos
                .FirstOrDefaultAsync(g => g.Identificador == id);

            if(genero is null)
            {
                return NotFound();
            }
            return genero;
        }

        [HttpGet("primerNombreConC")]
        public async Task<ActionResult<Genero>> PrimerRegistro()
        {
            var genero = await context.Generos
                .FirstOrDefaultAsync(g => g.Nombre.StartsWith("C"));

            if(genero is null)
            {
                return NotFound();
            }
            return genero;
        }

        [HttpGet("filtrar")]
        public async Task<IEnumerable<Genero>> Filtrar(string nombre)
        {
            return await context.Generos
                .Where(g => g.Nombre.Contains(nombre))
                .OrderBy(g => g.Nombre)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Genero genero)
        {
            var estatus1 = context.Entry(genero).State;
            context.Add(genero);
            var estatus2 = context.Entry(genero).State;
            await context.SaveChangesAsync();
            var estatus3 = context.Entry(genero).State;
            return Ok();
        }

        [HttpPost("varios")]
        public async Task<ActionResult> Post(Genero[] generos)
        {
            context.AddRange(generos);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}