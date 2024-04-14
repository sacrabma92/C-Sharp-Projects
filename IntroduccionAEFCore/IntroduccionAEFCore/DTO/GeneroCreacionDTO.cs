using System.ComponentModel.DataAnnotations;

namespace IntroduccionAEFCore.DTO
{
    public class GeneroCreacionDTO
    {
        [StringLength(maximumLength: 150)]
        public string Nombre { get; set; } = null!;
    }
}
