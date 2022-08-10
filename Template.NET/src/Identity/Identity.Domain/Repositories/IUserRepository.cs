using Identity.Domain.Entities;
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
    /// <param name="userName">Имя пользователя</param>
    /// <param name="userPassword">Пароль пользователя</param>
    /// <returns><see cref="User"/></returns>
    public Task<User> RegisterAsync(string userName, string userPassword);
}