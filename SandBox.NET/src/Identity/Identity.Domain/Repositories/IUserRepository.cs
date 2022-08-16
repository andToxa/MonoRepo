using Identity.Domain.Entities;
using Identity.Domain.ValueObjects;
using System.Threading.Tasks;

namespace Identity.Domain.Repositories;

/// <summary>
/// Репозиторий <see cref="User"/>
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Регистрация пользователя
    /// </summary>
    /// <param name="userName"><see cref="UserName"/></param>
    /// <param name="userPassword"><see cref="UserPassword"/></param>
    /// <returns><see cref="User"/></returns>
    public Task<User> RegisterAsync(UserName userName, UserPassword userPassword);
}