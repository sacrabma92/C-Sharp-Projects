namespace Pacientes.Entidades
{
    public class Ejercicios
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public List<PacientePeso> PacientePeso { get; set; }
    }
}
