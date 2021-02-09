using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure.Common.Extensions.MediatR
{
    /// <summary>Методы-расширения для <see cref="IMediator"/></summary>
    public static class MediatRExtensions
    {
        /// <summary>Добавление MediatR.</summary>
        /// <param name="services">Коллекция сервисов.</param>
        /// <returns><see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddMediator(this IServiceCollection services) => services
            .AddMediatR(services.GetType())
            .AddPipelineBehavior()
            .AddDomainHandlers();

        /// <summary>Добавление обработчиков.</summary>
        /// <param name="services">Коллекция сервисов</param>
        /// <returns><see cref="IServiceCollection"/></returns>
        private static IServiceCollection AddDomainHandlers(this IServiceCollection services) => services
            .Scan(scan =>
            {
                scan
                    .FromAssemblies(Assembly.Load(nameof(Application)))
                    .AddClasses(classes => classes.AssignableTo(typeof(IRequestHandler<>))).AsImplementedInterfaces()
                    .AddClasses(classes => classes.AssignableTo(typeof(IRequestHandler<,>))).AsImplementedInterfaces()
                    .AddClasses(classes => classes.AssignableTo(typeof(INotificationHandler<>))).AsImplementedInterfaces()
                    .WithScopedLifetime();
            });

        /// <summary>Добавление обработчика <see cref="IPipelineBehavior{TRequest, TResponse}"/>.</summary>
        /// <param name="services">Коллекция сервисов</param>
        /// <returns><see cref="IServiceCollection"/></returns>
        private static IServiceCollection AddPipelineBehavior(this IServiceCollection services) => services
            .Scan(scan =>
            {
                scan
                    .FromAssemblies(Assembly.Load(nameof(Application)))
                    .AddClasses(classes => classes
                        .AssignableTo(typeof(IPipelineBehavior<,>)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime();
            });
    }
}
