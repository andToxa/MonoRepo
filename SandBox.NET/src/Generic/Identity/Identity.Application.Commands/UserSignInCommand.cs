using MediatR;
using System;

namespace Identity.Application.Commands;

/// <summary>
/// Команда аутентификации пользователя
/// </summary>
public record UserSignInCommand : IRequest<string>
{
    /// <summary>
    /// Конструктор <see cref="UserSignInCommand"/>
    /// </summary>
    /// <param name="name"><see cref="Name"/></param>
    /// <param name="password"><see cref="Password"/></param>
    public UserSignInCommand(string name, string password)
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