using System;

namespace Identity.Domain.ValueObjects;

/// <summary>
/// Пароль пользователя
/// </summary>
public record UserPassword
{
    private readonly string _password;

    /// <summary>
    /// Ошибка "Некорректный пароль пользователя"
    /// </summary>
    public const string UserPasswordIncorrectErrorMessage = "Некорректный пароль пользователя";

    private UserPassword(string password)
    {
        // todo добавить инварианты пароля
        _password = IsValid(password)
            ? password
            : throw new ArgumentException(UserPasswordIncorrectErrorMessage, nameof(password));
    }

    /// <summary>
    /// Создание <see cref="UserPassword"/>
    /// </summary>
    /// <param name="password">Пароль пользователя</param>
    /// <returns><see cref="UserPassword"/></returns>
    public static UserPassword New(string password)
    {
        return new UserPassword(password);
    }

    /// <summary>
    /// Проверка валидности пароля пользователя
    /// </summary>
    /// <param name="password">Пароль пользователя</param>
    /// <returns><see cref="bool"/></returns>
    public static bool IsValid(string password)
    {
        // todo добавить проверок
        return !string.IsNullOrWhiteSpace(password);
    }

    /// <summary>
    /// Неявное преобразование в <see cref="string"/>
    /// </summary>
    /// <param name="userPassword"><see cref="UserPassword"/></param>
    /// <returns><see cref="string"/></returns>
    public static implicit operator string(UserPassword userPassword)
    {
        return userPassword.ToString();
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return _password;
    }

    /// <summary>
    /// Параметры пароля пользователя
    /// </summary>
    public static class Options
    {
        /// <summary>
        /// Требуется наличие цифр
        /// </summary>
        public const bool RequireDigit = true;

        /// <summary>
        /// Требуемая минимальная длина пароля
        /// </summary>
        public const int RequiredLength = 8;

        /// <summary>
        /// Требуется наличие букв в нижнем регистре
        /// </summary>
        public const bool RequireLowercase = true;

        /// <summary>
        /// Требуется наличие букв в верхнем регистре
        /// </summary>
        public const bool RequireUppercase = true;

        /// <summary>
        /// Требуемое количество уникальных символов
        /// </summary>
        public const int RequiredUniqueChars = 1;

        /// <summary>
        /// Требуется наличие символов
        /// </summary>
        public const bool RequireNonAlphanumeric = true;
    }
}