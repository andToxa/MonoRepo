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
    /// Регистрация <see cref="User"/> по <see cref="UserName"/>
    /// </summary>
    /// <param name="userName"><see cref="UserName"/></param>
    /// <param name="userPassword"><see cref="UserPassword"/></param>
    /// <returns><see cref="User"/></returns>
    public Task<User> RegisterByUserNameAsync(UserName userName, UserPassword userPassword);

    /// <summary>
    /// Получение <see cref="User"/> по <see cref="UserName"/>
    /// </summary>
    /// <param name="userName"><see cref="UserName"/></param>
    /// <param name="userPassword"><see cref="UserPassword"/></param>
    /// <returns><see cref="User"/></returns>
    public Task<User> GetByUserNameAsync(UserName userName, UserPassword userPassword);
}