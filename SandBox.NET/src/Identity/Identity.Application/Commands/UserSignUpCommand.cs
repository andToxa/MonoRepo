using Identity.Application.Events;
using Identity.Domain.Repositories;
using Identity.Domain.ValueObjects;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

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
        Name = Domain.ValueObjects.UserName.IsValid(name)
            ? name
            : throw new ArgumentException(Domain.ValueObjects.UserName.UserNameIncorrectErrorMessage, nameof(name));
        Password = UserPassword.IsValid(password)
            ? password
            : throw new ArgumentException(UserPassword.UserPasswordIncorrectErrorMessage, nameof(password));
    }

    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Пароль пользователя
    /// </summary>
    public string Password { get; }

    /// <summary>
    /// Обработчик <see cref="UserSignUpCommand"/>
    /// </summary>
    public class Handler : IRequestHandler<UserSignUpCommand, UserSignedUpEvent>
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Конструктор <see cref="Handler"/>
        /// </summary>
        /// <param name="userRepository"><see cref="IUserRepository"/></param>
        public Handler(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        /// <inheritdoc />
        public async Task<UserSignedUpEvent> Handle(UserSignUpCommand request, CancellationToken cancellationToken)
        {
            var userName = UserName.New(request.Name);
            var userPassword = UserPassword.New(request.Password);
            var user = await _userRepository.RegisterAsync(userName, userPassword);
            var userRegisteredEvent = new UserSignedUpEvent(id: user.Id, userName: user.Name);
            return userRegisteredEvent;
        }
    }
}