namespace Pacientes.Entidades
{
    public class PacientePeso
    {
        public int Id { get; set; }
        public int DietaId { get; set; }
        public int EjerciciosId { get; set; }
        public int PacienteId { get; set; }
        public Dieta Dieta { get; set; }
        public Ejercicios Ejercicios { get; set; }
        public Paciente Paciente { get; set; }

    }
}
