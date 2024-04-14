using AutoMapper;
using IntroduccionAEFCore.DTO;
using IntroduccionAEFCore.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntroduccionAEFCore.Controllers
{
    [Route("api/generos")]
    [ApiController]
    public class GenerosControllers : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public GenerosControllers(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(GeneroCreacionDTO generoCreacion)
        {
            // Forma Manual
            //var genero = new Genero
            //{
            //    Nombre = generoCreacion.Nombre
            //};
            var genero = mapper.Map<Genero>(generoCreacion);
            context.Add(genero);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("varios")]
        public async Task<ActionResult> Post(GeneroCreacionDTO[] generosCreacionDTO)
        {
            var generos = mapper.Map<Genero[]>(generosCreacionDTO);
            context.AddRange(generos);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
