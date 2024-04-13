using EFCorePeliculas.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace EFCorePeliculas.Controllers
{
    [ApiController]
    [Route("api/generos")]
    public class GenerosController : ControllerBase
    {
        // Creamos la variable para buscar en DbContext
        private readonly ApplicationDbContext context;
        // Creamos la relacion con DbConbtext
        public GenerosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Genero>> Get()
        {
            // Trae todos los generos
            return await context.Generos.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Genero>> Get(int id)
        {
            // Trae el genero por id
            var genero = await context.Generos.SingleOrDefaultAsync(g => g.Identificador == id);
            if(genero == null)
            {
                return NotFound();
            }
            return genero;
        }

        [HttpGet("primerNombreConC")]
        public async Task<ActionResult<Genero>> Primer()
        {
            // Traer el primero genero que encuentre con la letra C. 
            // Trae solo 1 registro
            var genero = await context.Generos.FirstOrDefaultAsync(g => g.Nombre.StartsWith("C"));

            if(genero is null)
            {
                return NotFound();
            }
            return genero;
        }

        [HttpGet("filtrarNombreCon-A-C")]
        public async Task<IEnumerable<Genero>> Filtrar()
        {
            return await context.Generos.Where(
                // Traer todos los Generos que empuizen con la letra A o C
                g => g.Nombre.StartsWith("A") || g.Nombre.StartsWith("C")
                ).ToListAsync();
        }

        [HttpGet("filtrarNombre")]
        public async Task<IEnumerable<Genero>> Filtrar(string nombre)
        {
            // Trae lista de generos que CONTENGAN el parametro buscando, puede ser una letra 
            return await context.Generos.Where(
                g => g.Nombre
                .Contains(nombre))
                .ToListAsync();
        }

        [HttpGet("OrdenarPorNombreAscendente")]
        public async Task<IEnumerable<Genero>> FiltrarOrdenarPorNombreAsc(string nombre)
        {
            // Trae lista de generos que CONTENGAN el parametro buscando, puede ser una letra.
            // Y ordena de forma Ascendente el Nombre       
            return await context.Generos
                .Where(g => g.Nombre.Contains(nombre))
                .OrderBy(g => g.Nombre)
                .ToListAsync();
        }

        [HttpGet("YOrdenarPorNombreDescemdemnte")]
        public async Task<IEnumerable<Genero>> FiltrarOrdenarPorNombreDesc(string nombre)
        {
            // Trae lista de generos que CONTENGAN el parametro buscando, puede ser una letra.
            // Y ordena de forma Descendente el Nombre       
            return await context.Generos
                .Where(g => g.Nombre.Contains(nombre))
                .OrderByDescending(g => g.Nombre)
                .ToListAsync();
        }

        [HttpGet("paginacion")]
        public async Task<ActionResult>
    }
}