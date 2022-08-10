using Common.Domain.Entities;
using Common.Domain.ValueObjects;
using Identity.Domain.ValueObjects;

namespace Identity.Domain.Entities;

/// <summary>
/// Пользователь
/// </summary>
public class User : IEntity<User>
{
    /// <summary>
    /// Конструктор <see cref="User"/>
    /// </summary>
    /// <param name="id"><see cref="Id{User}"/></param>
    /// <param name="userName"><see cref="UserName"/></param>
    public User(Id<User> id, UserName userName)
    {
        Id = id;
        UserName = userName;
    }

    /// <inheritdoc />
    public Id<User> Id { get; }

    /// <summary>
    /// <see cref="Identity.Domain.ValueObjects.UserName"/>
    /// </summary>
    public UserName UserName { get; }

    /// <summary>
    /// <see cref="Common.Domain.ValueObjects.Email"/>
    /// </summary>
    public Email? Email { get; }

    /// <summary>
    /// <see cref="Common.Domain.ValueObjects.Phone"/>
    /// </summary>
    public Phone? Phone { get; }
}