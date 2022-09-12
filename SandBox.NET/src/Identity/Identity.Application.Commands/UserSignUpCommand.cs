using Identity.Application.Events;
using MediatR;

namespace Identity.Application.Commands;

/// <summary>
/// Команда регистрации пользователя
/// </summary>
public record UserSignUpCommand : IRequest<UserSignedUpEvent>
{
    /// <summary>
    /// Конструктор <see cref="UserSignUpCommand"/>
    /// </summary>
    /// <param name="name"><see cref="Name"/></param>
    /// <param name="password"><see cref="Password"/></param>
    public UserSignUpCommand(string name, string password)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Password = password ?? throw new ArgumentNullException(nameof(password));
    }

    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Пароль пользователя
    /// </summary>
    public string Password { get; }
}