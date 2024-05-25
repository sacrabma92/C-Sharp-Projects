namespace Pacientes.Entidades
{
    public class TipoEnfermedad
    {
        public int Id { get; set; }
        public int AlimentacionId { get; set; }
        public int DietaId { get; set; }
        public int EnfermedadId { get; set; }
        public Alimentacion Alimentacion { get; set; }
        public Dieta Dieta { get; set; }
        public Enfermedad Enfermedad { get; set; }

    }
}
