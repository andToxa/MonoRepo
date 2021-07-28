using Common.Application.Services;
using Common.Domain.Services;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Application.Extensions
{
    /// <summary>Класс-расширение для <see cref="IServiceCollection"/></summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>Добавление общих сервисов уровня приложения</summary>
        /// <param name="services"><see cref="IServiceCollection"/></param>
        /// <param name="configuration"><see cref="IConfiguration"/></param>
        /// <returns><seealso cref="IServiceCollection"/></returns>
        public static IServiceCollection AddApplicationCommon(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(services.GetType());

            // шина событий
            services.AddScoped<IEventBusService, EventBusService>();

            return services;
        }
    }
}