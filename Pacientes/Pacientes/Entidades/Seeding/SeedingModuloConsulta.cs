using Microsoft.EntityFrameworkCore;

namespace Pacientes.Entidades.Seeding
{
    public static class SeedingModuloConsulta
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var frutas = new Alimentacion() { Id = 1, nombre = "fruta" };
            var verdura = new Alimentacion() { Id = 2, nombre = "verdura" };
            var granos = new Alimentacion() { Id = 3, nombre = "granos" };
            var proteinasMagras = new Alimentacion() { Id = 4, nombre = "proteinas magras" };
            var grasaSaludables = new Alimentacion() { Id = 5, nombre = "grasas saludables" };
            var azucar = new Alimentacion() { Id = 6, nombre = "azúcar" };
            var alimentosProcesados = new Alimentacion() { Id = 7, nombre = "alimentos procesados" };
            var agua = new Alimentacion() { Id = 8, nombre = "agua" };
            var lacteos = new Alimentacion() { Id = 9, nombre = "lacteos" };

            modelBuilder.Entity<Alimentacion>().HasData(frutas, verdura, granos, proteinasMagras, grasaSaludables, azucar, alimentosProcesados, agua, lacteos);

            var pesobajo = new Dieta() { Id = 1, nombre = "peso bajo" };
            var pesonormal = new Dieta() { Id = 2, nombre = "peso normal" };
            var sobrepeso = new Dieta() { Id = 3, nombre = "sobre peso" };
            var obesidad = new Dieta() { Id = 4, nombre = "obesidad" };

            modelBuilder.Entity<Dieta>().HasData(pesobajo, pesonormal, sobrepeso, obesidad);

            var desnutricion = new Enfermedad() { Id = 1, nombre = "desnutricion" };
            var anorexia = new Enfermedad() { Id = 2, nombre = "anorexia" };
            var bulimia = new Enfermedad() { Id = 3, nombre = "bulimia" };
            var depresion = new Enfermedad() { Id = 4, nombre = "depresion" };
            var ansiedad = new Enfermedad() { Id = 5, nombre = "ansiedad" };
            //var diabetesTipo2 = new Enfermedad() { Id = 6, nombre = "diabetes tipo 2" };
            //var enfermedadCoronaria = new Enfermedad() { Id = 7, nombre = "enfermedad coronaria" };
            //var sindromMetabolico = new Enfermedad() { Id = 8, nombre = "sindrome metabolico" };
            //var hipertensionArterial = new Enfermedad() { Id = 9, nombre = "hipertension arterial" };
            //var accidenteCerebrovascular = new Enfermedad() { Id = 10, nombre = "accidente cerebrovascular" };
            //var enfermedadArterialPeriferica = new Enfermedad() { Id = 11, nombre = "enfermedad arterial periférica" };
            //var enferApneaSueñomedadArterialPeriférica = new Enfermedad() { Id = 12, nombre = "Apnea del sueño" };
            //var Osteoartritis = new Enfermedad() { Id = 13, nombre = "Osteoartritiso" };
            //var cancerDeMama = new Enfermedad() { Id = 14, nombre = "cáncer de mama" };
            //var cancerDeColon= new Enfermedad() { Id = 15, nombre = "cáncer de colon" };
            //var cancerDeProstata= new Enfermedad() { Id = 16, nombre = "cáncer próstata" };
            
            modelBuilder.Entity<Enfermedad>().HasData(desnutricion, anorexia, bulimia, depresion, ansiedad);

            var caminar = new Ejercicios() { Id = 1, nombre = "caminar" };
            var correr = new Ejercicios() { Id = 2, nombre = "correr" };
            var nadar = new Ejercicios() { Id = 3, nombre = "nadar" };
            var yoga = new Ejercicios() { Id = 4, nombre = "yoga" };
            var gym = new Ejercicios() { Id = 5, nombre = "gimnacio" };

            modelBuilder.Entity<Ejercicios>().HasData(caminar, correr, nadar, yoga, gym);

            // var pesobajo1 = new Peso() { Id = 1, nombre = "peso bajo" };
            // var pesonormal1 = new Peso() { Id = 2, nombre = "peso normal" };
            // var sobrepeso1 = new Peso() { Id = 3, nombre = "sobre peso" };
            // var obesidad1 = new Peso() { Id = 4, nombre = "obesidad" };

            // modelBuilder.Entity<Peso>().HasData(pesobajo1, pesonormal1, sobrepeso1, obesidad1);

            //var num1 = new EjercicioPeso() { EjercicioId = 5, PacientePesoId = 1 };
            //var num2 = new EjercicioPeso() { EjercicioId = 1, PacientePesoId = 4 };
            //var num3 = new EjercicioPeso() { EjercicioId = 2, PacientePesoId = 3 };
            //var num4 = new EjercicioPeso() { EjercicioId = 2, PacientePesoId = 4 };
            //var num5 = new EjercicioPeso() { EjercicioId = 5, PacientePesoId = 2 };
            //var num6 = new EjercicioPeso() { EjercicioId = 5, PacientePesoId = 2 };

        }
    }
}
