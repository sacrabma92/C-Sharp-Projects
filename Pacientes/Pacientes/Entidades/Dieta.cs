namespace Pacientes.Entidades
{
    public class Dieta
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public List<PacientePeso> PacientePeso { get; set; }
        public List<TipoEnfermedad> TiposEnfermedad { get; set; }
    }
}
