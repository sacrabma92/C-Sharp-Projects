using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Vehiculos;

public sealed class Vehiculo : Entity
{
  public Vehiculo(Guid id): base(id)
  {}
  public Modelo? Modelo { get; set; }
  public Vin? Vin { get; set; }
  public Direccion? Direccion { get; private set; }
  public decimal Precio { get; private set; }

  public string? TipoMoneda { get; private set; }
  public decimal Mantenimiento { get; private set; }

  public string? MantenimientoTipoMoneda { get; private set; }
  public DateTime? FechaUltimoAlquiler { get; private set; }

  public List<Accesorio> Accesorios { get; private set; } = new();
}