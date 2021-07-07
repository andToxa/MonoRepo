# SwaggerExtension
## Prerequisites
* Swashbuckle.AspNetCore
* Swashbuckle.AspNetCore.Annotations
* Microsoft.Extensions.DependencyInjection
* Microsoft.Extensions.Configuration
* Microsoft.Extensions.Configuration.Binder
## Using
* Add **services.AddSwaggerExtension(Configuration)** to ConfigureServices in Startup.cs
* Add **app.UseSwaggerExtension()** to Configure in Startup.cs
* Add configuration into appsettings.json or appsettings.Development.json (see SwaggerExtensions.appsettings.json)
