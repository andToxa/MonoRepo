﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Infrastructure.Common.Extensions.Logging
{
    /// <summary>Методы-расширения для подключения и использования<see cref="Serilog"/></summary>
    public static class SerilogExtensions
    {
        /// <summary>Использование <see cref="Serilog"/></summary>
        /// <param name="app"><see cref="IHostBuilder"/></param>
        /// <returns><seealso cref="IHostBuilder"/></returns>
        public static IWebHostBuilder UseSerilog(this IWebHostBuilder app)
        {
            return app.UseSerilog((context, configuration) =>
            {
                configuration
                    .Enrich.FromLogContext();
            });
        }
    }
}