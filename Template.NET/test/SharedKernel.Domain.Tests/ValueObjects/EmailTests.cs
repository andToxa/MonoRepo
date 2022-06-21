using SharedKernel.Domain.ValueObjects;
using Xunit;

namespace Common.Domain.Tests.ValueObjects;

/// <summary>
/// Тесты <see cref="Email"/>
/// </summary>
public class EmailTests
{
    /// <summary>
    /// Проверка адреса электронной почты на корректность
    /// </summary>
    /// <param name="email">Проверяемый адрес электронной почты</param>
    /// <param name="isValidExpected">Ожидаемый результат проверки</param>
    [Theory]
    [InlineData("qwe@asd.zxc", true)]
    [InlineData("qwe+qwe@asd.zxc", true)]
    [InlineData("qwe@йцу.фыв", true)]
    [InlineData("", false)]
    [InlineData(null, false)]
    [InlineData("null", false)]
    [InlineData("null@", false)]
    [InlineData("@qwe.asd", false)]
    [InlineData("qwe@asd. zxc", false)]
    [InlineData("qwe@asd.zxc ", false)]
    public void ValidEmailTest(string email, bool isValidExpected)
    {
        Assert.Equal(isValidExpected, Email.IsValid(email));
    }

    /// <summary>
    /// Проверка соответствия строкового представления <see cref="Email"/> исходной строке
    /// </summary>
    /// <param name="email">Исходная строка с адресом</param>
    [Theory]
    [InlineData("qwe@asd.zxc")]
    public void EmailToStringTest(string email)
    {
        Assert.Equal(email, Email.Parse(email).ToString());
    }
}