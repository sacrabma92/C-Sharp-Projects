using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCorePeliculas.Entidades.Configuraciones
{
    public class GeneroConfig : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            // TABLA GENERO
            // Configurar el atributo identificador como PrimaryKey
            builder.HasKey(prop => prop.Identificador);
            // Configuramos el tamaño maximo de Nombre
            builder.Property(prop => prop.Nombre)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
