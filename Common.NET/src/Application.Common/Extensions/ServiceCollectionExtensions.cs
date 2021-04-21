using Application.Common.Services;
using Domain.Common.Services;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Common.Extensions
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
            services.AddMediator();
            services.AddScoped<IEventBusService, EventBusService>();
            return services;
        }

        private static IServiceCollection AddMediator(this IServiceCollection services)
        {
            // шина событий
            services.AddMediatR(services.GetType());
            services.AddScoped<IEventBusService, EventBusService>();

            return services;
        }
    }
}