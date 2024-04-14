using IntroduccionAEFCore.Entidades;
using IntroduccionAEFCore.Entidades.Seeding;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace IntroduccionAEFCore
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
              
        }
        // Aqui se configuran todos las APIs Fluentes
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Linea que busca las configuracion que se ubieran creado en la carpeta Configuraciones de las API Fluente
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            // Creacion del Seeding cargar datos iniciales
            //SeedingInicial.Seed(modelBuilder);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            // Configurar que todos los campos de tipo string sean de maximo 150 caracteres
            configurationBuilder.Properties<string>().HaveMaxLength(150);
        }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Actor> Actores { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<PeliculaActor> PeliculasActores { get; set; }
    }
}
