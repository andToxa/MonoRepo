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
    [HttpPost("register")]
    public async Task<ActionResult<UserSignedUpEvent>> RegisterAsync(UserSignUpCommand command)
    {
        return await Mediator.Send(command);
    }
}