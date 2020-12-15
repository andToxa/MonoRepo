using Microsoft.Extensions.Hosting;
using Serilog;

namespace Infrastructure.Extensions.Logging
{
    /// <summary>Методы-расширения для подключения и использования<see cref="Serilog"/></summary>
    public static class SerilogExtensions
    {
        /// <summary>Использование <see cref="Serilog"/></summary>
        /// <param name="app"><see cref="IHostBuilder"/></param>
        /// <returns><seealso cref="IHostBuilder"/></returns>
        public static IHostBuilder UseSerilogExtension(this IHostBuilder app)
        {
            return app.UseSerilog((context, configuration) =>
            {
                configuration
                    .Enrich.FromLogContext();
            });
        }
    }
}