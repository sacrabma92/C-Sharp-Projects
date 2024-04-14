namespace IntroduccionAEFCore.Entidades
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public bool EnCines { get; set; }
        public DateTime FechaEstreno { get; set; }
        public HashSet<Comentario> Comentarios { get; set; } = null!;
        public HashSet<Genero> Generos { get; set; } = null!;
        public List<PeliculaActor> PeliculasActores { get; set; } = null!;
    }
}
