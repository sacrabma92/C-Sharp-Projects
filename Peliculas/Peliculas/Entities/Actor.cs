using System.ComponentModel.DataAnnotations.Schema;

namespace Peliculas.Entities
{
    public class Actor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Biografia { get; set; }
        //[Column(TypeName = "Date")]
        public DateTime? FechaNacimiento { get; set; }
    }
}
