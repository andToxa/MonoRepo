using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;

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
        // add JWT Authentication
        var securityScheme = new OpenApiSecurityScheme
        {
            Name = "JWT Authentication",
            Description = "Enter JWT Bearer token **_only_**",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.Http,
            Scheme = JwtBearerDefaults.AuthenticationScheme, // must be lower case
            BearerFormat = "JWT",
            Reference = new OpenApiReference
            {
                Id = JwtBearerDefaults.AuthenticationScheme,
                Type = ReferenceType.SecurityScheme
            }
        };
        options.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            { securityScheme, Array.Empty<string>() }
        });
        options.OperationFilter<SwaggerBearerOperationFilter>();
    }
}