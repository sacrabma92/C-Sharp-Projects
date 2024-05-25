namespace Pacientes.Entidades
{
    public class Enfermedad
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public List<TipoEnfermedad> TiposEnfermedad { get; set; }
    }
}
