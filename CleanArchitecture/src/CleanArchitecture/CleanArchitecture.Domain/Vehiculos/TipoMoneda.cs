namespace CleanArchitecture.Domain.Vehiculos;

// Esta clase representa un tipo de moneda. Es un tipo de registro, lo que significa que es inmutable (no se puede cambiar) después de su creación.
public record TipoMoneda
{
  // Este campo estático representa la ausencia de moneda. Se inicializa con una cadena vacía.
  public static readonly TipoMoneda None = new("");
  // Este campo estático representa la moneda del dólar estadounidense. Se inicializa con la cadena "USD".
  public static readonly TipoMoneda Usd = new("USD");
  // Este campo estático representa la moneda del euro. Se inicializa con la cadena "EUR".
  public static readonly TipoMoneda Eur = new("EUR");
  // Este constructor privado impide crear instancias directamente. En su lugar, debe usar los métodos estáticos proporcionados. Toma un argumento de cadena codigo (código) y lo asigna a la propiedad privada Codigo.
  private TipoMoneda(string codigo) => Codigo = codigo;
// Esta propiedad almacena el código de moneda como una cadena. Es de solo lectura después de la inicialización (init).
  public string? Codigo {get; init;}
// Este campo estático es una colección de solo lectura (IReadOnlyCollection<TipoMoneda>) que contiene todos los tipos de moneda predefinidos. Se inicializa con una matriz que contiene Usd y Eur.
  public static readonly IReadOnlyCollection<TipoMoneda> All = new[]
  {
    Usd,
    Eur
  };
// Este método estático toma una cadena codigo (código) como entrada y trata de encontrar un tipo de moneda coincidente en la colección All. Utiliza FirstOrDefault para encontrar el primer elemento donde la propiedad Codigo coincide con el código proporcionado. Si no encuentra ninguna coincidencia, lanza una ApplicationException con un mensaje que indica el tipo de moneda no válido.
  public static TipoMoneda FromCodigo(string codigo)
  {
    return All.FirstOrDefault(c => c.Codigo == codigo) ?? 
      throw new ApplicationException("El tipo de moneda es invalido");
  }
}