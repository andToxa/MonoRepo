namespace Identity.Domain.ValueObjects;

/// <summary>
/// Имя/ник пользователя
/// </summary>
public record UserName
{
    private readonly string _userName;

    /// <summary>
    /// Конструктор <see cref="UserName"/>
    /// </summary>
    /// <param name="userName">Имя пользователя</param>
    public UserName(string userName)
    {
        _userName = userName;
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return _userName;
    }
}