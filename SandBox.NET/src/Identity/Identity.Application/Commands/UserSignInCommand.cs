using Identity.Domain.Repositories;
using Identity.Domain.Services;
using Identity.Domain.ValueObjects;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

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

    /// <inheritdoc />
    public class Handler : IRequestHandler<UserSignInCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtGenerator _jwtGenerator;

        /// <summary>
        /// Конструктор <see cref="Handler"/>
        /// </summary>
        /// <param name="userRepository"><see cref="IUserRepository"/></param>
        /// <param name="jwtGenerator"><see cref="IJwtGenerator"/></param>
        public Handler(IUserRepository userRepository, IJwtGenerator jwtGenerator)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _jwtGenerator = jwtGenerator ?? throw new ArgumentNullException(nameof(jwtGenerator));
        }

        /// <inheritdoc />
        public async Task<string> Handle(UserSignInCommand request, CancellationToken cancellationToken)
        {
            var userName = UserName.New(request.Name);
            var userPassword = UserPassword.New(request.Password);
            var user = await _userRepository.GetByUserNameAsync(userName, userPassword);
            return _jwtGenerator.CreateToken(user);
        }
    }
}