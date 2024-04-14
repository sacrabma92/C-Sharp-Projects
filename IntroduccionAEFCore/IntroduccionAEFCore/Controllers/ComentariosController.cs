using AutoMapper;
using IntroduccionAEFCore.DTO;
using IntroduccionAEFCore.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntroduccionAEFCore.Controllers
{
    [Route("api/peliculas/{peliculaId:int}/comentarios")]
    [ApiController]
    public class ComentariosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ComentariosController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(int peliculaId, ComentarioCreacionDTO comentarioCreacionDTO)
        {
            var comentario = mapper.Map<Comentario>(comentarioCreacionDTO);
            comentario.PeliculaId = peliculaId;
            context.Add(comentario);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
