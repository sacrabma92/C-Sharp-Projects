namespace Pacientes.Entidades
{
    public class Paciente
    {
        public int Id { get; set; }
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string genero { get; set; }
        public DateTime fechanac { get; set; }
        public List<Imc> Imc { get; set; }
        public List<PacientePeso> PacientePeso { get; set; }
    }
}
