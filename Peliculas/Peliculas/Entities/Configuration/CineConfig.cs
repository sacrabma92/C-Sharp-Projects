using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Peliculas.Entities.Configuration
{
    public class CineConfig : IEntityTypeConfiguration<Cine>
    {
        public void Configure(EntityTypeBuilder<Cine> builder)
        {
            // Tabla Cine
            builder.Property(prop => prop.Nombre)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
