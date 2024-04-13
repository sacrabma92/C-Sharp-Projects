
namespace EFCorePeliculas.Entidades
{
    public class Cine
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public NetTopologySuite.Geometries.Point Ubicacion { get; set; }
        // Relacion con la Tabla CineOferta
        public CineOferta CineOferta { get; set; }
        // Coleccion de salas de Cine
        public HashSet<SalaDeCine> SalasDeCine { get; set; }
    }
}
