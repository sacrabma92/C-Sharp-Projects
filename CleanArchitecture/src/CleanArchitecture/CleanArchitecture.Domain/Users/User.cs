using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Users;

// Declara una clase pública y sellada llamada User. sealed indica que esta clase no puede ser heredada.
public sealed class User : Entity 
{
  private User(
    Guid id,
    Nombre nombre,
    Apellido apellido,
    Email email
    ): base(id)
  {
    Nombre = nombre;
    Apellido = apellido;
    Email = email;
  }

  public Nombre? Nombre {get; private set;}
  public Apellido? Apellido{get; private set;}
  public Email? Email{get; private set;}


  public static User Create(
    Nombre nombre,
    Apellido apellido,
    Email email
  )
  {
    var user = new User(Guid.NewGuid(), nombre, apellido, email);
    return user;
  }
}