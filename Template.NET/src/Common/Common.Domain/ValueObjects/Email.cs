using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Common.Domain.ValueObjects;

/// <summary>
/// Электронная почта
/// </summary>
public record Email
{
    private string _email;

    /// <summary>
    /// Конструктор <see cref="Email"/>
    /// </summary>
    /// <param name="email">Электронная почта</param>
    public Email(string email)
    {
        if (!IsValid(email))
        {
            throw new ArgumentException("Incorrect email", nameof(email));
        }

        _email = email ?? throw new ArgumentException("Incorrect email", nameof(email));
    }

    /// <summary>
    /// Получение <see cref="Email"/> из строки
    /// </summary>
    /// <param name="email">Строка с адресом электронной почты</param>
    /// <returns><see cref="Email"/></returns>
    public static Email Parse(string email) => new Email(email);

    /// <summary>
    /// Проверка корректности адреса электронной почты
    /// </summary>
    /// <param name="email">Адрес электронной почты</param>
    /// <returns><see cref="bool"/></returns>
    public static bool IsValid(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return false;
        }

        try
        {
            // Normalize the domain
            email = Regex.Replace(email, @"(@)(.+)$", DomainMapper, RegexOptions.None, TimeSpan.FromMilliseconds(200));

            // Examines the domain part of the email and normalizes it.
            string DomainMapper(Match match)
            {
                // Use IdnMapping class to convert Unicode domain names.
                var idn = new IdnMapping();

                // Pull out and process domain name (throws ArgumentException on invalid)
                var domainName = idn.GetAscii(match.Groups[2].Value);

                return match.Groups[1].Value + domainName;
            }
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
        catch (ArgumentException)
        {
            return false;
        }

        try
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }

    /// <inheritdoc />
    public override string ToString() => _email;
}