using Microsoft.AspNetCore.Identity;

namespace ApiPeliculas.Modelos
{
    public class AppUsuario : IdentityUser
    {
        // Añadir campso personalizados
        public string Nombre { get; set; }
    }
}
