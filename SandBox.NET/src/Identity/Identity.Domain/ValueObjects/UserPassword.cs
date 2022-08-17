using Common.Domain.Exceptions;
using System.Collections.Generic;
using System.Linq;

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
        _password = IsValid(password, out var errors)
            ? password
            : throw new DomainException(UserPasswordIncorrectErrorMessage) { Data = { { "Errors", errors } } };
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
    /// <param name="errors">Список ошибок</param>
    /// <returns><see cref="bool"/></returns>
    public static bool IsValid(string password, out List<string> errors)
    {
        errors = new List<string>();

        if (string.IsNullOrWhiteSpace(password) || password.Length < Options.RequiredLength)
        {
            errors.Add(nameof(Options.RequiredLength));
        }

        if (Options.RequireDigit && !password.Any(char.IsDigit))
        {
            errors.Add(nameof(Options.RequireDigit));
        }

        var letters = string.Concat(password.Where(char.IsLetter));
        if (Options.RequireLowercase && letters.All(c => c != char.ToLower(c)))
        {
            errors.Add(nameof(Options.RequireLowercase));
        }

        if (Options.RequireUppercase && letters.All(c => c != char.ToUpper(c)))
        {
            errors.Add(nameof(Options.RequireUppercase));
        }

        if (letters.ToLower().Distinct().Count() < Options.RequiredUniqueChars)
        {
            errors.Add($"{nameof(Options.RequiredUniqueChars)} = {Options.RequiredUniqueChars}");
        }

        if (Options.RequireNonAlphanumeric && password.All(char.IsLetterOrDigit))
        {
            errors.Add(nameof(Options.RequireNonAlphanumeric));
        }

        return errors.Count == 0;
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
        public const int RequiredUniqueChars = 2;

        /// <summary>
        /// Требуется наличие символов
        /// </summary>
        public const bool RequireNonAlphanumeric = true;
    }
}