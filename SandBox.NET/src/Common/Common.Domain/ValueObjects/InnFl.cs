using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Common.Domain.ValueObjects;

/// <summary>
/// ИНН физического лица
/// </summary>
public abstract record InnFl
{
    private const int ValidLength = 12;

    private static readonly Regex RegexPattern = new Regex($"^\\d{{{ValidLength}}}$", RegexOptions.Singleline | RegexOptions.Compiled);
    private static readonly string[] CheckSumsValidationExceptions = Array.Empty<string>(); // todo есть список выданных ИНН с некорректными контрольными суммами

    private readonly string _value;

    private InnFl(string value)
    {
        _value = value;
    }

    /// <summary>
    /// Создание <see cref="InnFl"/> из строки
    /// </summary>
    /// <param name="value">Строка с ИНН</param>
    /// <returns><see cref="InnFl"/></returns>
    /// <exception cref="ArgumentException">Исключение при некорректной строке</exception>
    public static InnFl Parse(string value)
    {
        if (IsValid(value))
        {
            return new InnFl(value);
        }
        else
        {
            throw new ArgumentException("Некорректный ИНН", nameof(value));
        }
    }

    /// <inheritdoc />
    public override string ToString() => _value;

    private static bool IsValid(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return false;
        }

        if (value.Length != ValidLength)
        {
            return false;
        }

        if (!RegexPattern.IsMatch(value))
        {
            return false;
        }

        if (!CheckSumsValid(value) && !CheckSumsValidationExceptions.Contains(value))
        {
            return false;
        }

        return true;
    }

    private static bool CheckSumsValid(string value)
    {
        int[] factor10 = { 2, 4, 10, 3, 5, 9, 4, 6, 8, 0 };
        int[] factor11 = { 7, 2, 4, 10, 3, 5, 9, 4, 6, 8, 0 };
        int[] factor12 = { 3, 7, 2, 4, 10, 3, 5, 9, 4, 6, 8, 0 };

        return value.Length switch
        {
            10 => Check(value, factor10),
            12 => Check(value, factor11) && Check(value, factor12),
            _ => false
        };

        bool Check(string innValue, IReadOnlyCollection<int> factorArray)
        {
            var sum = factorArray.Select((t, i) => int.Parse(innValue[i].ToString()) * t).Sum();
            var remainder = sum % 11;

            return (remainder <= 9 ? remainder : remainder % 10) == int.Parse(innValue[factorArray.Count - 1].ToString());
        }
    }
}