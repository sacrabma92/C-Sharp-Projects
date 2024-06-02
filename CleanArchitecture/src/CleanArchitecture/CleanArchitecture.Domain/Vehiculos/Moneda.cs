namespace CleanArchitecture.Domain.Vehiculos;
// Este código define una clase Moneda para representar cantidades de dinero con su tipo de moneda asociado. Permite realizar operaciones básicas como la suma de dos monedas del mismo tipo, crear monedas con valor cero y verificar si una moneda es equivalente a cero. El uso de un tipo de registro garantiza la inmutabilidad de las monedas.
public record Moneda(
  decimal Monto, 
  TipoMoneda TipoMoneda
){
  public static Moneda operator +(Moneda primero, Moneda segundo){
    if(primero.TipoMoneda != segundo.TipoMoneda)
    {
      throw new InvalidOperationException("El tipo de moneda debe ser el mismo");
    }
    return new Moneda(primero.Monto + segundo.Monto, primero.TipoMoneda);
  }

  public static Moneda Zero() => new(0, TipoMoneda.None);
  public static Moneda Zero(TipoMoneda tipoMoneda) => new(0, tipoMoneda);
  public bool IsZero => this == Zero(TipoMoneda);
}