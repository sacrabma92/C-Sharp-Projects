using AutoMapper;
using Peliculas.DTOs;
using Peliculas.Entities;

namespace Peliculas.Servicios
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Actor, ActorDTO>();
            CreateMap<Cine, CineDTO>()
                .ForMember(dto => dto.Latitud, ent => ent.MapFrom(prop => prop.Ubicacion.Y))
                .ForMember(dto => dto.Longitud, ent => ent.MapFrom(prop => prop.Ubicacion.X));

            CreateMap<Genero, GeneroDTO>();
            CreateMap<Pelicula, PeliculaDTO>()
                .ForMember(dto => dto.Cines, ent => ent.MapFrom(prop => prop.SalasDeCine.Select(s => s.Cine)))
                .ForMember(dto => dto.Actores, ent => ent.MapFrom(prop => prop.PeliculasActores.Select(s => s.Actor)));
        }
    }
}
