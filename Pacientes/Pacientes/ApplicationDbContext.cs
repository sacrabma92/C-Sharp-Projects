using Microsoft.EntityFrameworkCore;
using Pacientes.Entidades;
using Pacientes.Entidades.Seeding;
using System.Reflection;

namespace Pacientes
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedingModuloConsulta.Seed(modelBuilder);

            // Paciente
            modelBuilder.Entity<Paciente>().Property(prop => prop.cedula)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<Paciente>().Property(prop => prop.nombre)
                .HasMaxLength(100)
                .IsRequired();

            // Alimentacion
            modelBuilder.Entity<Alimentacion>().Property(prop => prop.nombre)
                .HasMaxLength(150)
                .IsRequired();

            // Enfermedad
            modelBuilder.Entity<Enfermedad>().Property(prop => prop.nombre)
                .HasMaxLength(100)
                .IsRequired();

            // TipoEnfermedad

            // Dieta
            modelBuilder.Entity<Enfermedad>().Property(prop => prop.nombre)
                .HasMaxLength(100)
                .IsRequired();

            // Ejercicios
            modelBuilder.Entity<Ejercicios>().Property(prop => prop.nombre)
                .HasMaxLength(100)
                .IsRequired();


           // modelBuilder.Entity<EjercicioPeso>().HasKey(prop => new {prop.EjercicioId, prop.PacientePesoId});

        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Alimentacion> Alimentaciones { get; set; }
        public DbSet<Dieta> Dietas { get; set; }
        public DbSet<Enfermedad> Enfermedades { get; set; }
        public DbSet<PacientePeso> PacientesPesos { get; set; }
        public DbSet<Ejercicios> Ejercicios { get; set; }
        public DbSet<TipoEnfermedad> TiposEnfermedades { get; set; }
        public DbSet<Imc> Imc { get; set; }
    }
}
