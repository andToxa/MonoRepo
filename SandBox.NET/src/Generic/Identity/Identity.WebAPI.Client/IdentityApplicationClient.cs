using Identity.Application.Abstractions;
using Identity.Application.Commands;
using Identity.Application.Events;

namespace Identity.WebAPI.Client;

/// <summary>
/// Клиент Identity.Application
/// </summary>
public class IdentityApplicationClient : IIdentityApplication
{
    /// <inheritdoc />
    public Task<UserSignedUpEvent> SignUpAsync(UserSignUpCommand command)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task<string> SignInAsync(UserSignInCommand command)
    {
        throw new NotImplementedException();
    }
}