using Common.Infrastructure.Extensions;
using Identity.Domain.Repositories;
using Identity.Domain.Services;
using Identity.Infrastructure.Database;
using Identity.Infrastructure.Database.Models;
using Identity.Infrastructure.Repositories;
using Identity.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace Identity.Infrastructure.Extensions;

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

        var connectionString = configuration.GetConnectionString("postgres");
        services.AddDbContextPool<DatabaseContext>(
            options =>
            {
                options.UseNpgsql(connectionString, builder => { builder.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName); });
                if (environment.IsDevelopment())
                {
                    options.EnableSensitiveDataLogging();
                    options.EnableDetailedErrors();
                }
            }, PoolSize);
        services.AddScoped<DbContext, DatabaseContext>();

        services.AddScoped<IJwtGenerator, JwtGenerator>();

        services.AddScoped<IUserRepository, UserRepository>();

        services.TryAddSingleton<ISystemClock, SystemClock>();
        var builder = services.AddIdentityCore<UserModel>();
        var identityBuilder = new IdentityBuilder(builder.UserType, builder.Services);
        identityBuilder.AddEntityFrameworkStores<DatabaseContext>();
        identityBuilder.AddSignInManager<SignInManager<UserModel>>();

        return services;
    }
}