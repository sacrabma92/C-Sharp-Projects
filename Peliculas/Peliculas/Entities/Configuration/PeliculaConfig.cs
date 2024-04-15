using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Peliculas.Entities.Configuration
{
    public class PeliculaConfig : IEntityTypeConfiguration<Pelicula>
    {
        public void Configure(EntityTypeBuilder<Pelicula> builder)
        {
            // Tabla Pelicula
            builder.Property(prop => prop.Titulo)
                .HasMaxLength(250)
                .IsRequired();
            builder.Property(prop => prop.PosterUrl)
                .HasMaxLength(500)
                .IsUnicode(false);
        }
    }
}
