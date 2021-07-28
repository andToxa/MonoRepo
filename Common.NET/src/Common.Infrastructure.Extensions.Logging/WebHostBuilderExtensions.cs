using Microsoft.AspNetCore.Hosting;
using Serilog;

namespace Common.Infrastructure.Extensions.Logging
{
    /// <summary>Класс-расширение для <see cref="IWebHostBuilder"/></summary>
    public static class WebHostBuilderExtensions
    {
        /// <summary>Логирование</summary>
        /// <param name="webHostBuilder"><see cref="IWebHostBuilder"/></param>
        /// <returns><seealso cref="IWebHostBuilder"/></returns>
        public static IWebHostBuilder UseLogging(this IWebHostBuilder webHostBuilder) =>
            webHostBuilder.UseSerilog((context, configuration) =>
            {
                configuration.UseLogging(context.Configuration);
            });
    }
}