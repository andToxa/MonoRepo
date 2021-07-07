using Microsoft.AspNetCore.Hosting;
using Serilog;
using Serilog.Formatting.Compact;

namespace Infrastructure.Common.Extensions.Logging
{
    /// <summary>Класс-расширение для <see cref="IWebHostBuilder"/></summary>
    public static class WebHostBuilderExtensions
    {
        /// <summary>Использование общей инфраструктуры</summary>
        /// <param name="webHostBuilder"><see cref="IWebHostBuilder"/></param>
        /// <returns><seealso cref="IWebHostBuilder"/></returns>
        public static IWebHostBuilder UseInfrastructureCommon(this IWebHostBuilder webHostBuilder)
        {
            webHostBuilder.UseLogging();
            return webHostBuilder;
        }

        private static IWebHostBuilder UseLogging(this IWebHostBuilder webHostBuilder) =>
            webHostBuilder.UseSerilog((context, configuration) =>
            {
                configuration
                    .WriteTo.Console(new CompactJsonFormatter())
                    .Enrich.FromLogContext();
            });
    }
}