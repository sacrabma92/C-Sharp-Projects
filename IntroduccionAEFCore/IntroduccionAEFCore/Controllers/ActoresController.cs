using AutoMapper;
using IntroduccionAEFCore.DTO;
using IntroduccionAEFCore.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntroduccionAEFCore.Controllers
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

        [HttpPost]
        public async Task<ActionResult> Post(ActorCreacionDTO actorCreacionDTO)
        {
            var actor = mapper.Map<Actor>(actorCreacionDTO);
            context.Add(actor);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
