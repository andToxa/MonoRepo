using Identity.Application.Commands;
using Identity.Application.Events;
using Identity.Application.Queries;

namespace Identity.WebAPI.Client;

/// <summary>
/// Клиент Identity.Application
/// </summary>
public class Client : IIdentityCommands, IIdentityQueries
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