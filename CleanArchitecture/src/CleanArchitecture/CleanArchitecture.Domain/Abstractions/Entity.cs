namespace CleanArchitecture.Domain.Abstractions;

public abstract class Entity 
{
  protected Entity(Guid id)
  {
    Id = id;
  }
  // Identificara a cada una de las entidades dentro de nuestro dominio.
  public Guid Id {get; init;}
}