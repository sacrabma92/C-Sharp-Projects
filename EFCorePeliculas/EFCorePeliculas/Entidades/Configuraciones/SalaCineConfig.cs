using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCorePeliculas.Entidades.Configuraciones
{
    public class SalaCineConfig : IEntityTypeConfiguration<SalaDeCine>
    {
        public void Configure(EntityTypeBuilder<SalaDeCine> builder)
        {
            // Tabla SalaDeCine
            builder.Property(prop => prop.Precio)
                .HasPrecision(precision: 9, scale: 2);
            builder.Property(prop => prop.TipoSalaDeCine)
                .HasDefaultValue(TipoSalaDeCine.DosDimensiones);
        }
    }
}
