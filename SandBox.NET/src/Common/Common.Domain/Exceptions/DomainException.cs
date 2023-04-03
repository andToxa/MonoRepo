using System;

namespace Common.Domain.Exceptions;

/// <summary>
/// Доменное исключение
/// </summary>
public class DomainException : Exception
{
    /// <summary>
    /// Конструктор <see cref="DomainException"/>
    /// </summary>
    /// <param name="message">Текст исключения</param>
    public DomainException(string? message)
        : base(message)
    {
    }
}