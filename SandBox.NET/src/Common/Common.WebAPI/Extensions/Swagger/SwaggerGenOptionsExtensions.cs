using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace Common.WebAPI.Extensions.Swagger;

/// <summary>
/// Методы-расширения для <see cref="SwaggerGenOptions"/>
/// </summary>
public static class SwaggerGenOptionsExtensions
{
    /// <summary>
    /// Добавление схемы Bearer
    /// </summary>
    /// <param name="options"><see cref="SwaggerGenOptions"/></param>
    public static void AddBearer(this SwaggerGenOptions options)
    {
        options.AddSecurityDefinition(name: JwtBearerDefaults.AuthenticationScheme, securityScheme: new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Description = $"Enter the {JwtBearerDefaults.AuthenticationScheme} Authorization string as following: `{JwtBearerDefaults.AuthenticationScheme} Generated-JWT-Token`",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = JwtBearerDefaults.AuthenticationScheme
        });
        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Name = JwtBearerDefaults.AuthenticationScheme,
                    In = ParameterLocation.Header,
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                },
                new List<string>()
            }
        });
        options.OperationFilter<SwaggerBearerOperationFilter>();
    }
}