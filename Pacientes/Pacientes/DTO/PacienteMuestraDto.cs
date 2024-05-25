namespace Pacientes.DTO
{
    public class PacienteMuestraDto
    {
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string genero { get; set; }
        public DateTime fechanac { get; set; }
        public List<ImcDto> Imc { get; set; }
        public List<PacientesPesoDto> PacientePeso { get; set; }
    }
}
