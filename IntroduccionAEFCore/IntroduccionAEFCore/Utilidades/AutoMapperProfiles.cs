using AutoMapper;
using IntroduccionAEFCore.DTO;
using IntroduccionAEFCore.Entidades;

namespace IntroduccionAEFCore.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<GeneroCreacionDTO, Genero>();
            CreateMap<ActorCreacionDTO, Actor>();
            CreateMap<ComentarioCreacionDTO, Comentario>();
            CreateMap<PeliculaCreacionDTO, Pelicula>()
                .ForMember(ent => ent.Generos, dto => 
                dto.MapFrom(campo => campo.Generos.Select(id => new Genero { Id = id })));
            CreateMap<PeliculaActorCreacionDTO, PeliculaActor>();
        }
    }
}
