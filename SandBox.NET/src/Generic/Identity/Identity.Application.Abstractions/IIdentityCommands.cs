using Common.Domain.ValueObjects;
using Identity.Application.Commands;
using Identity.Application.Events;
using System.Threading.Tasks;

namespace Identity.Application.Abstractions;

/// <summary>
/// Доступные команды Identity.Application
/// </summary>
public interface IIdentityCommands
{
    /// <summary>
    /// Регистрация пользователя
    /// </summary>
    /// <param name="command"><see cref="UserSignUpCommand"/></param>
    /// <returns><see cref="Id{T}"/></returns>
    public Task<UserSignedUpEvent> SignUp(UserSignUpCommand command);

    /// <summary>
    /// Аутентификация пользователя
    /// </summary>
    /// <param name="command"><see cref="UserSignInCommand"/></param>
    /// <returns>JWT</returns>
    public Task<string> SignInAsync(UserSignInCommand command);
}