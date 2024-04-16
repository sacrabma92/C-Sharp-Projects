using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using Peliculas.DTOs;
using Peliculas.Entities;

namespace Peliculas.Controllers
{
    [ApiController]
    [Route("api/cines")]
    public class CinesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CinesController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CineDTO>> Get()
        {
            return await context.Cines
                .ProjectTo<CineDTO>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        [HttpGet("carcanos")]
        public async Task<ActionResult> Get(double latidud, double longitud)
        {
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            var miUbicacion = geometryFactory.CreatePoint(new Coordinate(longitud, latidud));
            var distanciaMaximaEnMetros = 2000;

            var cines = await context.Cines
                .OrderBy(c => c.Ubicacion.Distance(miUbicacion))
                .Where(c => c.Ubicacion.IsWithinDistance(miUbicacion, distanciaMaximaEnMetros))
                .Select( c => new
                {
                    Nombre = c.Nombre,
                    Distancia = Math.Round(c.Ubicacion.Distance(miUbicacion))
                }).ToListAsync();
            return Ok(cines);
        }
    }
}
