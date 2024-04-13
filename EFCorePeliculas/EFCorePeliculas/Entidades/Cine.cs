
namespace EFCorePeliculas.Entidades
{
    public class Cine
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        //[Precision(precision: 9, scale: 1)]
        public decimal Precio { get; set; }
        public NetTopologySuite.Geometries.Point Ubicacion { get; set; }
    }
}
