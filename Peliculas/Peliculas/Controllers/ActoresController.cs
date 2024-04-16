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
                .Select(a => new ActorDTO {Id = a.Id, Nombre = a.Nombre})
                .ToListAsync();
        }

        [HttpGet("autommaper")]
        public async Task<IEnumerable<ActorDTO>> GetMapper()
        {
            return await context.Actores
                .ProjectTo<ActorDTO>(mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
