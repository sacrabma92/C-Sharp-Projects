using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace IntroduccionAEFCore.Entidades.Configuraciones
{
    public class GeneroConfig : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            var cienciaFiccion = new Genero { Id = 5, Nombre = "Ciencia Ficción" };
            var animacion = new Genero { Id = 6, Nombre = "Animación" };
            builder.HasData(cienciaFiccion, animacion);

            // Tabla Genero
            builder.Property(e => e.Nombre)
                .HasMaxLength(150);
        }
    }
}
