﻿using Infrastructure.Common.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    /// <summary>Класс-расширение для <see cref="IServiceCollection"/></summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>Добавление сервисов уровня инфраструктуры</summary>
        /// <param name="services"><see cref="IServiceCollection"/></param>
        /// <param name="configuration"><see cref="IConfiguration"/></param>
        /// <returns><seealso cref="IServiceCollection"/></returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddInfrastructureCommon(configuration);
            return services;
        }
    }
}