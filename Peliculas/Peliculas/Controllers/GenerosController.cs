using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
