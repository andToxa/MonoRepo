using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    /// <summary>Регистратор зависимостей</summary>
    public static class DependencyInjector
    {
        /// <summary>Добавление собственных сервисов</summary>
        /// <param name="services"><see cref="IServiceCollection"/></param>
        /// <param name="configuration"><see cref="IConfiguration"/></param>
        /// <returns><seealso cref="IServiceCollection"/></returns>
        public static IServiceCollection AddOwnServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }

        /// <summary>Использование собственных сервисов</summary>
        /// <param name="app"><see cref="IApplicationBuilder"/></param>
        /// <returns><seealso cref="IApplicationBuilder"/></returns>
        public static IApplicationBuilder UseOwnServices(this IApplicationBuilder app)
        {
            return app;
        }
    }
}