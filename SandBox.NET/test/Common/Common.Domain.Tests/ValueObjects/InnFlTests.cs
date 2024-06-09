using Common.Domain.ValueObjects;
using System;
using Xunit;

namespace Common.Domain.Tests.ValueObjects;

/// <summary>
/// Тесты <see cref="InnFlTests"/>
/// </summary>
public class InnFlTests
{
    /// <summary>
    /// Некорректная строка вызывает исключение
    /// </summary>
    /// <param name="innString">Строка ИНН</param>
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("StringString")]
    [InlineData("1234567890")]
    [InlineData("123456789012")]
    public void InvalidInnFlTests(string innString)
    {
        var e = Record.Exception(() => _ = InnFl.Parse(innString));

        Assert.NotNull(e);
        Assert.IsType<ArgumentException>(e);
    }

    /// <summary>
    /// Некорректная строка вызывает исключение
    /// </summary>
    /// <param name="innString">Строка ИНН</param>
    [Theory]
    [InlineData("964517071431")]
    public void ValidInnFlTests(string innString)
    {
        var inn = InnFl.Parse(innString);

        Assert.Equal(innString, inn.ToString());
    }
}