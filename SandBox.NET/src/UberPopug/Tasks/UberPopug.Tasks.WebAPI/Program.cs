using Common.WebAPI.Extensions.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

var openidConfiguration = await OpenIdConnectConfigurationRetriever.GetAsync("http://keycloak8080.localhost:8080/realms/uber-popug/.well-known/openid-configuration", new HttpDocumentRetriever() { RequireHttps = false }, CancellationToken.None);

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        options.Authority = "http://keycloak8080.localhost:8080/realms/uber-popug";
        options.Audience = "uber-popug-tasks";
        options.RequireHttpsMetadata = false; // todo только при разработке
        options.MetadataAddress = "http://keycloak8080.localhost:8080/realms/uber-popug/.well-known/openid-configuration";
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateAudience = false,
            ValidAudience = "account",

            ValidateIssuer = true,
            ValidIssuers = new[] { "http://keycloak8080.localhost:8080/realms/uber-popug" },

            ValidateIssuerSigningKey = true,
            IssuerSigningKeys = openidConfiguration.SigningKeys,

            RequireExpirationTime = true,
            ValidateLifetime = true,
            RequireSignedTokens = true,
        };
        options.Events = new JwtBearerEvents
        {
            OnTokenValidated = async context => { await Task.CompletedTask; },
            OnForbidden = context =>
            {
                _ = context;
                return Task.CompletedTask;
            },
            OnAuthenticationFailed = context =>
            {
                context.NoResult();

                context.Response.StatusCode = 401;
                context.Response.ContentType = "text/plain";

                return context.Response.WriteAsync(
                    builder.Environment.IsDevelopment()
                        ? context.Exception.ToString() // todo пустой ответ
                        : "An error occured processing your authentication.");
            }
        };
    });

builder.Services.AddAuthorization(options =>
{
    /*
    options.DefaultPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .AddAuthenticationSchemes("Firebase", "Custom")
        .Build();

    options.AddPolicy("FirebaseAdministrators", new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .AddAuthenticationSchemes("Firebase")
        .RequireClaim("role", "admin")
        .Build());
*/
    /*
    options.AddPolicy("AdministratorsOnly", policy =>
        policy.RequireRole("Administrator"));

    options.AddPolicy("EmployeesOnly", policy =>
        policy.RequireClaim("EmployeeNumber"));

    options.AddPolicy("Over21", policy =>
        policy.Requirements.Add(new MinimumAgeRequirement(21)));
*/
});

builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.Never;
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles; // todo надо ли?
});

builder.Services.AddSwaggerExtension(builder.Configuration);

var app = builder.Build();

app.UseAuthentication();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerExtension();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();