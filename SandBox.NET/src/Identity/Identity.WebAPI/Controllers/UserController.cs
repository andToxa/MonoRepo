using Common.Domain.ValueObjects;
using Common.WebAPI.Controllers;
using Identity.Application.Abstractions;
using Identity.Application.Commands;
using Identity.Application.Events;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Identity.WebAPI.Controllers;

/// <inheritdoc cref="BaseController"/>
public class UserController : BaseController, IIdentityApplication
{
    /// <summary>
    /// Регистрация пользователя
    /// </summary>
    /// <param name="command"><see cref="UserSignUpCommand"/></param>
    /// <returns><see cref="Id{T}"/></returns>
    [HttpPost("SignUp")]
    public async Task<UserSignedUpEvent> SignUpAsync(UserSignUpCommand command)
    {
        return await Mediator.Send(command);
    }

    /// <summary>
    /// Аутентификация пользователя
    /// </summary>
    /// <param name="command"><see cref="UserSignInCommand"/></param>
    /// <returns>JWT</returns>
    [HttpPost("SignIn")]
    public async Task<string> SignInAsync(UserSignInCommand command)
    {
        return await Mediator.Send(command);
    }
}