using Common.Infrastructure.Extensions;
using Common.WebAPI.Extensions.Swagger;
using Customers.Application.Extensions;
using Customers.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseLogging();

builder.Services.AddOptions();

builder.Services
    .AddAuthentication(options => options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = false,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("qwe")),
            ValidateIssuer = false,
            ValidIssuer = "Astral.ETP.Identity",
            ValidateAudience = false,
            ValidateLifetime = false
        };
        options.Events = new JwtBearerEvents
        {
            OnTokenValidated = async context =>
            {
                var userId = context?.Principal?.FindFirst("userGuid")?.Value ?? string.Empty;
                var claims = new List<Claim>
                {
                    new Claim("sub", userId)
                };
                var appIdentity = new ClaimsIdentity(claims);

                context?.Principal?.AddIdentity(appIdentity);

                await Task.CompletedTask;
            },
            OnForbidden = context =>
            {
                _ = context;
                return Task.CompletedTask;
            },
            OnAuthenticationFailed = context =>
            {
                _ = context;
                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddAuthorization(); // todo

builder.Services
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration, builder.Environment);

builder.Services.AddHealthChecks();

builder.Services
    .AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.Never);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerExtension(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerExtension();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapHealthChecks("/health");

app.MapControllers();

app.Run();