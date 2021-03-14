using Application.Common.CQRS;
using Domain.Common;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

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
            services.AddScoped<IEventBus, EventBus>();
            return services;
        }

        private static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services
                .AddMediatR(services.GetType());
            services
                .Scan(scan =>
                    scan
                        .FromAssemblies(Assembly.Load(nameof(Application)))
                        .AddClasses(classes => classes.AssignableTo(typeof(IPipelineBehavior<,>)))
                        .AddClasses(classes => classes.AssignableTo(typeof(IRequestHandler<>))).AsImplementedInterfaces()
                        .AddClasses(classes => classes.AssignableTo(typeof(IRequestHandler<,>))).AsImplementedInterfaces()
                        .AddClasses(classes => classes.AssignableTo(typeof(INotificationHandler<>))).AsImplementedInterfaces()
                        .WithScopedLifetime());
            return services;
        }
    }
}