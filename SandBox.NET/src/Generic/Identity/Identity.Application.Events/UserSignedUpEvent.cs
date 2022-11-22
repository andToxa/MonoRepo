namespace Identity.Application.Events;

/// <summary>
/// Событие "Пользователь зарегистрирован"
/// </summary>
public record UserSignedUpEvent
{
    /// <summary>
    /// Конструктор <see cref="UserSignedUpEvent"/>
    /// </summary>
    /// <param name="id"><see cref="Id"/></param>
    /// <param name="userName"><see cref="UserName"/></param>
    public UserSignedUpEvent(string id, string userName)
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