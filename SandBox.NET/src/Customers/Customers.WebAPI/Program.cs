using Common.Infrastructure.Extensions;
using Common.WebAPI.Extensions.Swagger;
using Customers.Application.Extensions;
using Customers.Infrastructure.Extensions;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseLogging();

builder.Services.AddOptions();

builder.Services.AddHealthChecks();

builder.Services
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration, builder.Environment);

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

app.UseAuthorization();

app.MapControllers();

app.Run();