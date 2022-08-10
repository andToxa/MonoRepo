using Identity.Infrastructure.Database.Models;

namespace Identity.Infrastructure.Services
{
    /// <summary>
    /// Генератор JWT
    /// </summary>
    public interface IJwtGenerator
    {
        /// <summary>
        /// Создание токена
        /// </summary>
        /// <param name="userModel"><see cref="UserModel"/></param>
        /// <returns>Токен</returns>
        string CreateToken(UserModel userModel);
    }
}