using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Formatting.Compact;

namespace Infrastructure.Common.Extensions.Logging
{
    /// <summary>Класс-расширение для <see cref="IHostBuilder"/></summary>
    public static class HostBuilderExtensions
    {
        /// <summary>Использование общей инфраструктуры</summary>
        /// <param name="hostBuilder"><see cref="IHostBuilder"/></param>
        /// <returns><seealso cref="IHostBuilder"/></returns>
        public static IHostBuilder UseConsoleLogging(this IHostBuilder hostBuilder) =>
            hostBuilder.UseSerilog((context, configuration) =>
            {
                configuration
                    .WriteTo.Console(new CompactJsonFormatter())
                    .Enrich.FromLogContext();
            });
    }
}