using Identity.Domain.Repositories;
using Identity.Domain.Services;
using Identity.Domain.ValueObjects;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.Application.Commands;

/// <summary>
/// Обработчик <see cref="UserSignInCommand"/>
/// </summary>
public class UserSignInCommandHandler : IRequestHandler<UserSignInCommand, string>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtGenerator _jwtGenerator;

    /// <summary>
    /// Конструктор <see cref="UserSignInCommand"/>
    /// </summary>
    /// <param name="userRepository"><see cref="IUserRepository"/></param>
    /// <param name="jwtGenerator"><see cref="IJwtGenerator"/></param>
    public UserSignInCommandHandler(IUserRepository userRepository, IJwtGenerator jwtGenerator)
    {
        _userRepository = userRepository;
        _jwtGenerator = jwtGenerator;
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