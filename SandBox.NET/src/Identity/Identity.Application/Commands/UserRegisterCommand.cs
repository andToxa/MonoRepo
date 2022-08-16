using Identity.Application.Events;
using Identity.Domain.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.Application.Commands;

/// <summary>
/// Команда регистрации пользователя
/// </summary>
public record UserRegisterCommand : IRequest<UserRegisteredEvent>
{
    /// <summary>
    /// Конструктор <see cref="UserRegisterCommand"/>
    /// </summary>
    /// <param name="userName"><see cref="UserName"/></param>
    /// <param name="password"><see cref="Password"/></param>
    public UserRegisterCommand(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }

    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string UserName { get; }

    /// <summary>
    /// Пароль пользователя
    /// </summary>
    public string Password { get; }

    /// <summary>
    /// Обработчик <see cref="UserRegisterCommand"/>
    /// </summary>
    public class Handler : IRequestHandler<UserRegisterCommand, UserRegisteredEvent>
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
        public async Task<UserRegisteredEvent> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.RegisterAsync(request.UserName, request.Password);
            var userRegisteredEvent = new UserRegisteredEvent(id: user.Id.ToString(), userName: user.UserName.ToString());
            return userRegisteredEvent;
        }
    }
}