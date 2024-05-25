namespace Pacientes.DTO
{
    public class PacienteCreacionDto
    {
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string genero { get; set; }
        public DateTime fechanac { get; set; }
        public ImcDto Imc { get; set; }
        public PacientePesoDto PacientePeso { get; set; }
    }
}
