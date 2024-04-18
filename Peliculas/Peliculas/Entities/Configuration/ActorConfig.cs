using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Peliculas.Entities.Configuration
{
    public class ActorConfig : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.Property(prop => prop.Nombre)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(x => x.Nombre).HasField("_nombre");
        }
    }
}
