using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Peliculas.Entities.Configuration
{
    public class PeliculaActorConfig : IEntityTypeConfiguration<PeliculaActor>
    {
        public void Configure(EntityTypeBuilder<PeliculaActor> builder)
        {
            // Tabña PeliculaActor
            builder.HasKey(prop => new { prop.PeliculaId, prop.ActorId });
            builder.Property(prop => prop.Personaje)
                .HasMaxLength(150);
        }
    }
}
