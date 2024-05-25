using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Pacientes.Controllers
{
    [Route("api/dietas")]
    [ApiController]
    public class DietasController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public DietasController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var dietas = await context.Dietas.ToListAsync();

            if(dietas is null)
            {
                return BadRequest();
            }

            return Ok(dietas);
        }
    }
}
