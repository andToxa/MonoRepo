using Identity.Domain.ValueObjects;
using Xunit;

namespace Identity.Domain.Tests.ValueObjects;

/// <summary>
/// Тесты <see cref="UserPassword"/>
/// </summary>
public class UserPasswordTests
{
    /// <summary>
    /// Проверка пароля на корректность
    /// </summary>
    /// <param name="password">Пароль</param>
    /// <param name="isValid">Корректность проверяемого пароля</param>
    [Theory]
    [InlineData("", false)]
    [InlineData("12345678", false)]
    [InlineData("qwerty12", false)]
    [InlineData("Qwerty12", false)]
    [InlineData("Qwerty12$", true)]
    [InlineData("!@#$%^&*(", false)]
    public void PasswordIsValidTest(string password, bool isValid)
    {
        Assert.Equal(isValid, UserPassword.IsValid(password, out _));
        var exception = Record.Exception(() =>
        {
            var userPassword = UserPassword.New(password);
        });
        Assert.Equal(isValid, exception is null);
    }
}