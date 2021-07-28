﻿using Common.Application.Events;
using Common.Application.Extensions;
using Example.Application.Commands;
using Example.Application.Events;
using Example.Application.Queries;
using Example.Domain.Events;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Example.Application.Extensions
{
    /// <summary>Класс-расширение для <see cref="IServiceCollection"/></summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>Добавление сервисов уровня приложения</summary>
        /// <param name="services"><see cref="IServiceCollection"/></param>
        /// <param name="configuration"><see cref="IConfiguration"/></param>
        /// <returns><seealso cref="IServiceCollection"/></returns>
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationCommon(configuration);

            // обработчики команд
            services.AddScoped<IRequestHandler<ExampleCommand, Unit>, ExampleCommandHandler>();

            // обработчики запросов
            services.AddScoped<IRequestHandler<ExampleQuery, ExampleQueryResult>, ExampleQueryHandler>();

            // обработчики событий
            services.AddScoped<INotificationHandler<Event<ExampleEvent>>, ExampleEventHandler>();

            return services;
        }
    }
}