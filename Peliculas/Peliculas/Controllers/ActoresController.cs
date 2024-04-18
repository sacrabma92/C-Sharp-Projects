using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Peliculas.DTOs;
using Peliculas.Entities;

namespace Peliculas.Controllers
{
    [Route("api/actores")]
    [ApiController]
    public class ActoresController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ActoresController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ActorDTO>> Get()
        {
            return await context.Actores
                .Select(a => new ActorDTO {Id = a.Id, Nombre = a.Nombre, FechaNacimiento = a.FechaNacimiento})
                .ToListAsync();
        }

        [HttpGet("autommaper")]
        public async Task<IEnumerable<ActorDTO>> GetMapper()
        {
            return await context.Actores
                .ProjectTo<ActorDTO>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(ActorCreacionDTO actorCreacionDTO)
        {
            var actor = mapper.Map<Actor>(actorCreacionDTO);
            context.Add(actor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("ModeloConectado/{id:int}")]
        public async Task<ActionResult> PutModeloConectado(ActorCreacionDTO actorCreacionDTO, int id)
        {
            var actorDB = await context.Actores.AsTracking().FirstOrDefaultAsync(a => a.Id == id);

            if(actorDB is null)
            {
                return NotFound();
            }

            actorDB = mapper.Map(actorCreacionDTO, actorDB);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("ModeloDesconectado/{id:int}")]
        public async Task<ActionResult> PutDesconectado(ActorCreacionDTO actorCreacionDTO, int id)
        {
            var existeActor = await context.Actores.AnyAsync(a => a.Id == id);

            if (!existeActor)
            {
                return NotFound();
            }

            var actor = mapper.Map<Actor>(actorCreacionDTO);
            actor.Id = id;

            context.Update(actor);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
