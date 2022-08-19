using Common.Domain.ValueObjects;
using Common.WebAPI.Controllers;
using Identity.Application.Commands;
using Identity.Application.Events;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Identity.WebAPI.Controllers;

/// <inheritdoc />
public class UserController : BaseController
{
    /// <summary>
    /// Регистрация пользователя
    /// </summary>
    /// <param name="command"><see cref="UserSignUpCommand"/></param>
    /// <returns><see cref="Id{T}"/></returns>
    [HttpPost("SignUp")]
    public async Task<ActionResult<UserSignedUpEvent>> SignUpAsync(UserSignUpCommand command)
    {
        return await Mediator.Send(command);
    }

    /// <summary>
    /// Аутентификация пользователя
    /// </summary>
    /// <param name="command"><see cref="UserSignInCommand"/></param>
    /// <returns>JWT</returns>
    [HttpPost("SignIn")]
    public async Task<ActionResult<string>> SignInAsync(UserSignInCommand command)
    {
        return await Mediator.Send(command);
    }
}