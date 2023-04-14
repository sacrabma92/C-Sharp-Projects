using System.ComponentModel.DataAnnotations;

namespace ApiPeliculas.Modelos.Dtos
{
    public class CategoriaDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligaroio")]
        [MaxLength(60, ErrorMessage = "El número máximo de caracteres es de 100!")]
        public string Nombre { get; set; }
    }
}
