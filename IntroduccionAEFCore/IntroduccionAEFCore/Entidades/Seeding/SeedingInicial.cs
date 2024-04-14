using Microsoft.EntityFrameworkCore;

namespace IntroduccionAEFCore.Entidades.Seeding
{
    public class SeedingInicial
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var samuelLJavkson = new Actor()
            {
                Id = 2,
                Nombre = "Samuel L. Jackson",
                FechaNacimiento = new DateTime(1948, 12, 21),
                Fortuna = 21000
            };
            var RobertDowneyJunio = new Actor()
            {
                Id = 3,
                Nombre = "Robert Downey Jr",
                FechaNacimiento = new DateTime(1965, 2, 12),
                Fortuna = 18000
            };
            modelBuilder.Entity<Actor>().HasData(samuelLJavkson, RobertDowneyJunio);

            var avengers = new Pelicula()
            {
                Id = 2,
                Titulo = "Avengers Endgame",
                EnCines = true,
                FechaEstreno = new DateTime(2019, 4, 22)
            };
            var SpiderManNWH = new Pelicula()
            {
                Id = 3,
                Titulo = "Spider-Man: No Way Home",
                EnCines = true,
                FechaEstreno = new DateTime(2021, 08, 15)
            };
            var spiderManSpiderVerse2 = new Pelicula()
            {
                Id = 4,
                Titulo = "Spider-Man: Across the Spider-Verse (Part One)",
                EnCines = false,
                FechaEstreno = new DateTime(2022, 04, 27)
            };
            modelBuilder.Entity<Pelicula>().HasData(avengers, SpiderManNWH, spiderManSpiderVerse2);

            var comentarioAvengers = new Comentario()
            {
                Id = 2,
                Recomendar = true,
                Contenido = "Muy buena!!",
                PeliculaId = avengers.Id
            };
            var comentarioAvengers2 = new Comentario()
            {
                Id = 3,
                Recomendar = true,
                Contenido = "Dura dura!!",
                PeliculaId = avengers.Id
            };
            var comentarioNWH = new Comentario()
            {
                Id = 5,
                Recomendar = true,
                Contenido = "No debieron hacer eso...",
                PeliculaId = SpiderManNWH.Id
            };
            modelBuilder.Entity<Pelicula>().HasData(comentarioAvengers, comentarioAvengers2, comentarioNWH);

            // Muchos a muchos con salto
            var tablaGeneroPelicula = "GeneroPelicula";
            var generoIdPropiedad = "GenerosId";
            var peliculaIdPropiedad = "PeliculasId";
            var cienciaFiccion = 5;
            var animacion = 6;

            modelBuilder.Entity(tablaGeneroPelicula).HasData(
                new Dictionary<string, object>
                {
                    [generoIdPropiedad] = cienciaFiccion,
                    [peliculaIdPropiedad] = avengers.Id
                },
                new Dictionary<string, object>
                {
                    [generoIdPropiedad] = cienciaFiccion,
                    [peliculaIdPropiedad] = SpiderManNWH.Id
                },
                new Dictionary<string, object>
                {
                    [generoIdPropiedad] = animacion,
                    [peliculaIdPropiedad] = spiderManSpiderVerse2.Id
                }
            );

            // Muchos a muchos sin Salto
            var samuelLJacksonSpiderManNWH = new PeliculaActor
            {
                ActorId = samuelLJavkson.Id,
                PeliculaId = SpiderManNWH.Id,
                Orden = 1,
                Personaje = "Nick Fury"
            };
            
            var samuelLJacksonAvengers = new PeliculaActor
            {
                ActorId = samuelLJavkson.Id,
                PeliculaId = avengers.Id,
                Orden = 2,
                Personaje = "Nick Fury"
            };  
            
            var robertDowneyJuniorAvengers = new PeliculaActor
            {
                ActorId = RobertDowneyJunio.Id,
                PeliculaId = avengers.Id,
                Orden = 1,
                Personaje = "Iron Man"
            };
            modelBuilder.Entity<PeliculaActor>().HasData(samuelLJacksonSpiderManNWH, samuelLJacksonAvengers, robertDowneyJuniorAvengers);
        }
    }
}
