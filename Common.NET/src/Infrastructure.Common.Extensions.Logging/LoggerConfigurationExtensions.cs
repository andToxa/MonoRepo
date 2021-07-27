using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Formatting.Compact;

namespace Infrastructure.Common.Extensions.Logging
{
    /// <summary>Методы расширения для <see cref="LoggerConfiguration"/></summary>
    internal static class LoggerConfigurationExtensions
    {
        /// <summary>Логирование</summary>
        /// <param name="loggerConfiguration"><see cref="LoggerConfiguration"/></param>
        /// <param name="configuration"><see cref="IConfiguration"/></param>
        internal static void UseLogging(this LoggerConfiguration loggerConfiguration, IConfiguration configuration)
        {
            // todo добавить варианты логирования в зависимости от конфигурации
            loggerConfiguration.UseConsoleLogging(configuration);
        }

        private static void UseConsoleLogging(this LoggerConfiguration loggerConfiguration, IConfiguration configuration)
        {
            loggerConfiguration
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .WriteTo.Console(new CompactJsonFormatter());
        }
    }
}