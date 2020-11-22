using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Infrastructure.Common.Extensions.OpenApi
{
    /// <summary>Методы-расширения для подключения и использования<see cref="OpenApi"/></summary>
    public static class SwaggerExtensions
    {
        private static Settings? _settings;

        /// <summary>Add services.AddSwaggerExtension(Configuration) to ConfigureServices in Startup.cs</summary>
        /// <param name="services"><see cref="IServiceCollection"/></param>
        /// <param name="configuration"><see cref="IConfiguration"/></param>
        public static void AddSwaggerExtension(this IServiceCollection services, IConfiguration configuration)
        {
            _settings = configuration.GetSection("Swagger").Get<Settings>() ?? new Settings()
            {
                RoutePrefix = "api-docs",
                DocumentTitle = string.Empty,
                Documents = new Dictionary<string, OpenApiInfo> { { "v1", new OpenApiInfo { Version = "v1" } } }
            };

            services.AddSwaggerGen(c =>
            {
                foreach (var (documentName, documentInfo) in _settings.Documents!) c.SwaggerDoc(documentName, documentInfo);

                var xmlDoc = Path.ChangeExtension((Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly()).Location, "xml");
                if (File.Exists(xmlDoc))
                {
                    c.IncludeXmlComments(xmlDoc);
                }

                c.CustomSchemaIds(type => type.FullName);
                c.EnableAnnotations();
            });
        }

        /// <summary>Add app.UseSwaggerExtension() to Configure in Startup.cs</summary>
        /// <param name="app"><see cref="IApplicationBuilder"/></param>
        public static void UseSwaggerExtension(this IApplicationBuilder app)
        {
            app.UseSwagger(c =>
            {
                c.RouteTemplate = string.Concat(_settings?.RoutePrefix, "/{documentName}/swagger.json");
                c.PreSerializeFilters.Add((swagger, httpReq) => { swagger.Servers = new List<OpenApiServer> { new OpenApiServer { Url = $"{httpReq.Scheme}://{httpReq.Host.Value}" } }; });
            });

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = _settings?.RoutePrefix;
                c.DocumentTitle = _settings?.DocumentTitle;
                foreach (var (documentName, documentInfo) in _settings?.Documents!)
                {
                    c.SwaggerEndpoint(
                        string.Join("/", string.Empty, _settings.RoutePrefix, documentName, "swagger.json"),
                        string.Join(" ", documentInfo.Title, documentInfo.Version));
                    c.DisplayRequestDuration();
                }
            });
        }

        private class Settings
        {
            public Dictionary<string, OpenApiInfo>? Documents { get; set; }

            public string? DocumentTitle { get; set; }

            public string? RoutePrefix { get; set; }
        }
    }
}