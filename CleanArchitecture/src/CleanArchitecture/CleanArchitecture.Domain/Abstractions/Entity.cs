namespace CleanArchitecture.Domain.Abstractions;

public abstract class Entity 
{
  private readonly List<IDomainEvent> _domainEvents = new();
  protected Entity(Guid id)
  {
    Id = id;
  }
  // Identificara a cada una de las entidades dentro de nuestro dominio.
  public Guid Id {get; init;}

  // GetDomainEvents: Permite obtener una lista de los eventos de dominio que han ocurrido, sin permitir su modificación directa desde fuera de la clase. 
  public IReadOnlyList<IDomainEvent> GetDomainEvents()
  {
    return _domainEvents.ToList();
  }

  // ClearDomainEvents: Permite limpiar todos los eventos de dominio registrados, probablemente después de que se hayan manejado o procesado.
  public void ClearDomainEvents()
  {
    _domainEvents.Clear();
  }

  // RaiseDomainEvent: Permite registrar un nuevo evento de dominio en la lista, generalmente llamando a este método desde dentro de la clase User cuando algo importante ocurre (como la creación o actualización de un usuario).
  protected void RaiseDomainEvent(IDomainEvent domainEvent)
  {
    _domainEvents.Add(domainEvent);
  }

}