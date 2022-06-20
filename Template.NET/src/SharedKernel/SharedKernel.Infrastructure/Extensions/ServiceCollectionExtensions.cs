using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SharedKernel.Infrastructure.Extensions
{
    /// <summary>Класс-расширения для <see cref="IServiceCollection"/></summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>Добавление общих сервисов уровня инфраструктуры</summary>
        /// <param name="services"><see cref="IServiceCollection"/></param>
        /// <param name="configuration"><see cref="IConfiguration"/></param>
        /// <returns><seealso cref="IServiceCollection"/></returns>
        public static IServiceCollection AddInfrastructureCommon(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}