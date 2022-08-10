namespace Identity.Application.Events;

/// <summary>
/// Событие "Пользователь зарегистрирован"
/// </summary>
public record UserRegisteredEvent
{
    /// <summary>
    /// Конструктор <see cref="UserRegisteredEvent"/>
    /// </summary>
    /// <param name="id"><see cref="Id"/></param>
    /// <param name="userName"><see cref="UserName"/></param>
    public UserRegisteredEvent(string id, string userName)
    {
        Id = id;
        UserName = userName;
    }

    /// <summary>
    /// ID пользователя
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// Логин пользователя
    /// </summary>
    public string UserName { get; }
}