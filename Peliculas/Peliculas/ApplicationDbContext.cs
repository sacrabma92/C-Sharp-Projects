using Microsoft.EntityFrameworkCore;
using Peliculas.Entities;

namespace Peliculas
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options) { }

        public DbSet<Genero> Generos { get; set; }
    }
}
