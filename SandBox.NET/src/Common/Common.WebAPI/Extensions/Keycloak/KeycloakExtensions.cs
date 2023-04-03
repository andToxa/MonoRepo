using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Common.WebAPI.Extensions.Keycloak;

/// <summary>
/// Методы расширения для работы с Keycloak
/// </summary>
public static class KeycloakExtensions
{
    /// <summary>
    /// Подключение аутентификации с использованием Keycloak
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/></param>
    /// <param name="realm">asd</param>
    public static void AddKeycloakAuthentication(this IServiceCollection services, string realm)
    {
        services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.Authority = realm;
                options.RequireHttpsMetadata = false; // todo только при разработке
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    RequireAudience = true,
                    ValidateAudience = true,
                    ValidAudience = "account",

                    ValidateIssuer = true,

                    RequireSignedTokens = true,
                    ValidateIssuerSigningKey = true,

                    RequireExpirationTime = true,
                    ValidateLifetime = true,
                };
                /*
                options.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        _ = context;
                        return Task.CompletedTask;
                    },
                    OnForbidden = context =>
                    {
                        _ = context;
                        return Task.CompletedTask;
                    },
                    OnAuthenticationFailed = async context =>
                    {
                        context.NoResult();

                        context.Response.StatusCode = 401;
                        context.Response.ContentType = "text/plain";

                        /*
                        return context.Response.WriteAsync(
                            builder.Environment.IsDevelopment()
                                ? context.Exception.ToString() // todo пустой ответ
                                : "An error occured processing your authentication.");
                                #1#

                        await context.Response.WriteAsync(context.Exception.Message);
                    }
                };
            */
            });
    }
}