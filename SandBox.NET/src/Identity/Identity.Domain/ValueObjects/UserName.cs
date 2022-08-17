using System;

namespace Identity.Domain.ValueObjects;

/// <summary>
/// Имя/ник пользователя
/// </summary>
public record UserName
{
    private readonly string _userName;

    /// <summary>
    /// Ошибка "Некорректное имя пользователя"
    /// </summary>
    public const string UserNameIncorrectErrorMessage = "Некорректное имя пользователя";

    private UserName(string userName)
    {
        _userName = IsValid(userName)
            ? userName
            : throw new ArgumentException(UserNameIncorrectErrorMessage, nameof(userName));
    }

    /// <summary>
    /// Создание <see cref="UserName"/>
    /// </summary>
    /// <param name="userName">Имя/ник пользователя</param>
    /// <returns><see cref="UserName"/></returns>
    public static UserName New(string userName)
    {
        return new UserName(userName);
    }

    /// <summary>
    /// Проверка валидности имени пользователя
    /// </summary>
    /// <param name="userName">Имя пользователя</param>
    /// <returns><see cref="bool"/></returns>
    public static bool IsValid(string userName)
    {
        // todo добавить проверок
        return !string.IsNullOrWhiteSpace(userName);
    }

    /// <summary>
    /// Неявное преобразование в <see cref="string"/>
    /// </summary>
    /// <param name="userName"><see cref="UserName"/></param>
    /// <returns><see cref="string"/></returns>
    public static implicit operator string(UserName userName)
    {
        return userName.ToString();
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return _userName;
    }
}