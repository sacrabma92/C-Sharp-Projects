using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Peliculas.Entities.Configuration
{
    public class GeneroConfig : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            // Tabla Genero
            builder.HasKey(prop => prop.Identificador);
            builder.Property(g => g.Nombre)
                .HasMaxLength(150)
                .IsRequired();
            // Cambiar el nombde de la columna cuando se crea en la BD
            //.HasColumnName("NombreGenero")

            // Configuracion de la nombres de las tablas y el schemma
            //builder.ToTable(name: "TablaGeneros", schema: "Peliculas");

            // Tabla Genero
            builder.Property(prop => prop.Nombre)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
