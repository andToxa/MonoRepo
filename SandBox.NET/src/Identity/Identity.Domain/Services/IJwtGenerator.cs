using Identity.Domain.Entities;

namespace Identity.Domain.Services;

/// <summary>
/// Генератор JWT
/// </summary>
public interface IJwtGenerator
{
    /// <summary>
    /// Создание токена для <see cref="User"/>
    /// </summary>
    /// <param name="user"><see cref="User"/></param>
    /// <returns>JWT</returns>
    public string CreateToken(User user);
}