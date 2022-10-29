using Common.Domain.Entities;
using Common.Domain.Entities.Abstractions;
using Common.Domain.ValueObjects;
using Identity.Domain.ValueObjects;

namespace Identity.Domain.Entities;

/// <summary>
/// Пользователь
/// </summary>
public class User : IEntity<User>
{
    private User(Id<User> id, UserName name)
    {
        Id = id;
        Name = name;
    }

    /// <inheritdoc />
    public Id<User> Id { get; }

    /// <summary>
    /// <see cref="Name"/>
    /// </summary>
    public UserName Name { get; }

    /// <summary>
    /// <see cref="Common.Domain.ValueObjects.Email"/>
    /// </summary>
    public Email? Email { get; }

    /// <summary>
    /// <see cref="Common.Domain.ValueObjects.Phone"/>
    /// </summary>
    public Phone? Phone { get; }

    /// <summary>
    /// Создание <see cref="User"/>
    /// </summary>
    /// <param name="id"><see cref="Id{User}"/></param>
    /// <param name="name"><see cref="Name"/></param>
    /// <returns><see cref="User"/></returns>
    public static User New(Id<User> id, UserName name)
    {
        return new User(id, name);
    }
}