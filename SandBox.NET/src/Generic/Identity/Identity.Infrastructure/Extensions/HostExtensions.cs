using Identity.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Identity.Infrastructure.Extensions;

/// <summary>
/// Методы расширения для <see cref="IHost"/>
/// </summary>
public static class HostExtensions
{
    /// <summary>
    /// Запуск миграций
    /// </summary>
    /// <param name="host"><see cref="IHost"/></param>
    public static void UseMigrations(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<DatabaseContext>();
        context.Database.Migrate();
    }
}