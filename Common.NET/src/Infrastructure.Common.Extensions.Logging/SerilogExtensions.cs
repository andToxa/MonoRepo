using Microsoft.Extensions.Hosting;
using Serilog;

namespace Infrastructure.Common.Extensions.Logging
{
    public static class SerilogExtensions
    {
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