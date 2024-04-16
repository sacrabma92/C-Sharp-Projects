using AutoMapper;
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

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PeliculaDTO>> Get(int id)
        {
            var pelicula = await context.Peliculas
                .Include(p => p.Generos)
                .Include(p => p.SalasDeCine)
                    .ThenInclude(c => c.Cine)
                .Include(p => p.PeliculasActores)
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
    }
}
