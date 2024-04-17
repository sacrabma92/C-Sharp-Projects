using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Peliculas.DTOs;
using Peliculas.Entities;

namespace Peliculas.Controllers
{
    [Route("api/peliculas")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PeliculasController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("eagerLoading/{id:int}")]
        public async Task<ActionResult<PeliculaDTO>> GetEagerLoading(int id)
        {
            var pelicula = await context.Peliculas
                .Include(p => p.Generos.OrderByDescending(g => g.Nombre))
                .Include(p => p.SalasDeCine)
                    .ThenInclude(c => c.Cine)
                .Include(p => p.PeliculasActores.Where(pa => pa.Actor.FechaNacimiento.Value.Year >= 1980))
                    .ThenInclude(pa => pa.Actor)
                .FirstOrDefaultAsync(x => x.Id == id);

            if(pelicula is null)
            {
                return NotFound();
            }

            var peliculaDTO = mapper.Map<PeliculaDTO>(pelicula);

            peliculaDTO.Cines = peliculaDTO.Cines.DistinctBy(x => x.Id).ToList();

            return peliculaDTO;
        }

        [HttpGet("eagerLoadingConProjectto/{id:int}")]
        public async Task<ActionResult<PeliculaDTO>> GetEagerLoadingConProjectTo(int id)
        {
            var pelicula = await context.Peliculas
                .ProjectTo<PeliculaDTO>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (pelicula is null)
            {
                return NotFound();
            }


            pelicula.Cines = pelicula.Cines.DistinctBy(x => x.Id).ToList();

            return pelicula;
        }

        [HttpGet("selectLoading/{id:int}")]
        public async Task<ActionResult> GetSelectLoading(int id)
        {
            var pelicula = await context.Peliculas.Select(p => new
            {
                Id = p.Id,
                Titulo = p.Titulo,
                Generos = p.Generos.OrderByDescending(g => g.Nombre).Select(g => g.Nombre).ToList(),
                PeliculasActores = p.PeliculasActores.Select(pa => new {ActordId = pa.ActorId, Personaje = pa.Personaje, NombreActor = pa.Actor.Nombre}),
                CatnidadCines = p.SalasDeCine.Select(s => s.CineId).Distinct().Count()
            }).FirstOrDefaultAsync(p => p.Id == id);

            if(pelicula is null) { return NotFound(); }

            return Ok(pelicula);
        }

        [HttpGet("explicitLoading/{id:int}")]
        public async Task<ActionResult<PeliculaDTO>> GetEplicitLoading(int id)
        {
            var pelicula = await context.Peliculas.FirstOrDefaultAsync(p => p.Id == id);

            await context.Entry(pelicula)
                .Collection(p => p.Generos)
                .LoadAsync();

            if(pelicula is null)
            {
                return NotFound();
            }

            var peliculaDto = mapper.Map<PeliculaDTO>(pelicula);
            return peliculaDto;
        }

        // Para poder usar esta metodologia toca instalar un paquete Proxies y toca configurarlos en la clase program
        [HttpGet("lazyLoading/{id:int}")]
        public async Task<ActionResult<List<PeliculaDTO>>> GetLazyLoading()
        {
            var peliculas = await context.Peliculas.ToListAsync();
            var peliculasDto = mapper.Map<List<PeliculaDTO>>(peliculas);
            return peliculasDto;
        }

        [HttpGet("agrupadaPorEstreno")]
        public async Task<ActionResult> GetAgrupadasPorCartelera()
        {
            var peliculasAgrupadas = await context.Peliculas.GroupBy(p => p.EnCartelera)
                .Select(g => new
                {
                    EnCartelera = g.Key,
                    Conteo = g.Count(),
                    Peliculas = g.ToList()
                }).ToListAsync();
            return Ok(peliculasAgrupadas);
        }

        [HttpGet("agruparPorCantidadDeGeneros")]
        public async Task<ActionResult> GetAgrupadasPorCantidadDeGeneros()
        {
            var peliculasAgrupadas = await context.Peliculas.GroupBy(p => p.Generos.Count())
                .Select(g => new
                {
                    Conteo = g.Key,
                    Titulos = g.Select(x => x.Titulo),
                    Generos = g.Select(p => p.Generos)
                                .SelectMany(gen => gen).Select(gen => gen.Nombre).Distinct()
                }).ToListAsync();
            return Ok( peliculasAgrupadas);
        }

        [HttpGet("filtrar")]
        public async Task<ActionResult<List<PeliculaDTO>>> Filtrar([FromQuery] PeliculasFiltroDTO peliculasFiltroDTO)
        {
            var peliculasQueryable = context.Peliculas.AsQueryable();

            if (!string.IsNullOrEmpty(peliculasFiltroDTO.Titulo))
            {
                peliculasQueryable = peliculasQueryable.Where(p => p.Titulo.Contains(peliculasFiltroDTO.Titulo));
            }

            if(peliculasFiltroDTO.EnCartelera)
            {
                peliculasQueryable = peliculasQueryable.Where(p => p.EnCartelera);
            }

            if(peliculasFiltroDTO.ProximosEstrenos)
            {
                var hoy = DateTime.Today;
                peliculasQueryable = peliculasQueryable.Where(p => p.FechaEstreno > hoy);
            }

            if(peliculasFiltroDTO.GeneroId != 0)
            {
                peliculasQueryable = peliculasQueryable.Where(p => p.Generos
                .Select(g => g.Identificador)
                .Contains(peliculasFiltroDTO.GeneroId));
            }

            // Concatenar que traiga tambien los generos
            var peliculas = await peliculasQueryable
                .Include(p => p.Generos).ToListAsync();

            return mapper.Map<List<PeliculaDTO>>(peliculas);
        }
    }
}
