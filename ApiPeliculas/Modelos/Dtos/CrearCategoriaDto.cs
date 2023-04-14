using System.ComponentModel.DataAnnotations;

namespace ApiPeliculas.Modelos.Dtos
{
    public class CrearCategoriaDto
    {
        // Esta valicación es importante sino se crea vacio el nombre de categoria
        [Required(ErrorMessage = "El nombre es obligaroio")]
        [MaxLength(60, ErrorMessage = "El número máximo de caracteres es de 100!")]
        public string Nombre { get; set; }
    }
}
