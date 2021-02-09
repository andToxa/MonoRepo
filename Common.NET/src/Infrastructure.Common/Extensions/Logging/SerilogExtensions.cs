using Microsoft.AspNetCore.Hosting;
using Serilog;

namespace Infrastructure.Common.Extensions.Logging
{
    /// <summary>Методы-расширения для подключения и использования<see cref="Serilog"/></summary>
    public static class SerilogExtensions
    {
        /// <summary>Использование <see cref="Serilog"/></summary>
        /// <param name="app"><see cref="IWebHostBuilder"/></param>
        /// <returns><seealso cref="IWebHostBuilder"/></returns>
        public static IWebHostBuilder UseLogging(this IWebHostBuilder app)
        {
            return app.UseSerilog((context, configuration) =>
            {
                configuration
                    .WriteTo.Console()
                    .Enrich.FromLogContext();
            });
        }
    }
}