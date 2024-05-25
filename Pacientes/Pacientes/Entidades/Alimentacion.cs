namespace Pacientes.Entidades
{
    public class Alimentacion
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public List<TipoEnfermedad> TiposEnfermedad { get; set; }
    }
}
