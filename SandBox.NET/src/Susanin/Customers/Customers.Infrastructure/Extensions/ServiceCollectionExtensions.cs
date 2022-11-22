using Common.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Customers.Infrastructure.Extensions;

/// <summary>Класс-расширение для <see cref="IServiceCollection"/></summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Размер пула БД
    /// </summary>
    private const int PoolSize = 128;

    /// <summary>Добавление сервисов уровня инфраструктуры</summary>
    /// <param name="services"><see cref="IServiceCollection"/></param>
    /// <param name="configuration"><see cref="IConfiguration"/></param>
    /// <param name="environment"><see cref="IHostEnvironment"/></param>
    /// <returns><seealso cref="IServiceCollection"/></returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
    {
        services.AddCommonInfrastructure(configuration);

        return services;
    }
}