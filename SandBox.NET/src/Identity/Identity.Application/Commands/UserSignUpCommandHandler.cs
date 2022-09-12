using Identity.Application.Events;
using Identity.Domain.Repositories;
using Identity.Domain.ValueObjects;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.Application.Commands;

/// <summary>
/// Обработчик <see cref="UserSignUpCommand"/>
/// </summary>
public class UserSignUpCommandHandler : IRequestHandler<UserSignUpCommand, UserSignedUpEvent>
{
    private readonly IUserRepository _userRepository;

    /// <summary>
    /// Конструктор <see cref="UserSignUpCommandHandler"/>
    /// </summary>
    /// <param name="userRepository"><see cref="IUserRepository"/></param>
    public UserSignUpCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    /// <inheritdoc />
    public async Task<UserSignedUpEvent> Handle(UserSignUpCommand request, CancellationToken cancellationToken)
    {
        var userName = UserName.New(request.Name);
        var userPassword = UserPassword.New(request.Password);
        var user = await _userRepository.RegisterByUserNameAsync(userName, userPassword);
        var userRegisteredEvent = new UserSignedUpEvent(id: user.Id, userName: user.Name);
        return userRegisteredEvent;
    }
}