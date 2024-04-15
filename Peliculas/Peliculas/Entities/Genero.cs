using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Peliculas.Entities
{
    // COnfiguracion de la nombres de las tablas y el schemma
    //[Table("TablaGeneros", Schema = "peliculas")]
    public class Genero
    {
        //[Key]
        public int Identificador { get; set; }
        //[MaxLength(150)]
        //[StringLength(150)]
        //[Required]

        // Configuracion del nombre de la columna en la BD
        //[Column("NombreGenero")]
        public string Nombre { get; set; }
        public HashSet<Pelicula> Peliculas { get; set; }
    }
}
