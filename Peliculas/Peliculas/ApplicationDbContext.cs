using Microsoft.EntityFrameworkCore;
using Peliculas.Entities;

namespace Peliculas
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options) { }

        // Configuración del API Fluent
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Tabla Genero
            modelBuilder.Entity<Genero>().HasKey(prop => prop.Identificador);
            modelBuilder.Entity<Genero>().Property(g => g.Nombre)
                .HasMaxLength(150)
                .IsRequired();
                // Cambiar el nombde de la columna cuando se crea en la BD
                //.HasColumnName("NombreGenero")

            // Configuracion de la nombres de las tablas y el schemma
            //modelBuilder.Entity<Genero>().ToTable(name: "TablaGeneros", schema: "Peliculas");

            // Tabla Genero
            modelBuilder.Entity<Actor>().Property(prop => prop.Nombre)
                .HasMaxLength(150)
                .IsRequired();
            modelBuilder.Entity<Actor>().Property(prop => prop.FechaNacimiento)
                .HasColumnType("date");

            // Tabla Cine
            modelBuilder.Entity<Cine>().Property(prop => prop.Nombre)
                .HasMaxLength(150)
                .IsRequired();

            // Tabla Pelicula
            modelBuilder.Entity<Pelicula>().Property(prop => prop.Titulo)
                .HasMaxLength(250)
                .IsRequired();
            modelBuilder.Entity<Pelicula>().Property(prop => prop.FechaEstreno)
                .HasColumnType("date");
            modelBuilder.Entity<Pelicula>().Property(prop => prop.PosterUrl)
                .HasMaxLength(500)
                .IsUnicode(false);

            // Tabla CineOferta
            modelBuilder.Entity<CineOferta>().Property(prop => prop.PorcentajeDescuento)
                .HasPrecision(precision: 5, scale: 2);
            modelBuilder.Entity<CineOferta>().Property(prop => prop.FechaInicio)
                .HasColumnType("date");
            modelBuilder.Entity<CineOferta>().Property(prop => prop.FechaFin)
                .HasColumnType("date");

            // Tabla SalaDeCine
            modelBuilder.Entity<SalaDeCine>().Property(prop => prop.Precio)
                .HasPrecision(precision: 5, scale: 2);
        }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Actor> Actores { get; set; }
        public DbSet<Cine> Cines { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<CineOferta> CineOfertas { get; set; }
        public DbSet<SalaDeCine> SalasDeCine { get; set; }
    }
}
