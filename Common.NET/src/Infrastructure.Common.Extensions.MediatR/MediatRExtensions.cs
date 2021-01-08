using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure.Common.Extensions.MediatR
{
    internal static class MediatRExtensions
    {
        private static string ApplicationProjectNameSpace => "Application"; // todo проверить корректность регистрации

        /// <summary>
        /// Добавление MediatR.
        /// </summary>
        /// <param name="services">Коллекция сервисов.</param>
        /// <returns><see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddMediator(this IServiceCollection services) => services
            .AddMediatR(services.GetType()) // todo проверить корректность регистрации
            .AddPipelineBehavior()
            .AddDomainHandlers();

        /// <summary>
        /// Добавление обработчиков.
        /// </summary>
        /// <param name="services">Коллекция сервисов</param>
        /// <returns><see cref="IServiceCollection"/></returns>
        private static IServiceCollection AddDomainHandlers(this IServiceCollection services) => services
            .Scan(scan =>
            {
                scan
                    .FromAssemblies(Assembly.Load(ApplicationProjectNameSpace))
                    .AddClasses(classes => classes
                        .AssignableTo(typeof(IRequestHandler<>)))
                    .AsImplementedInterfaces()
                    .AddClasses(classes => classes
                        .AssignableTo(typeof(IRequestHandler<,>)))
                    .AddClasses(classes => classes
                        .AssignableTo(typeof(INotificationHandler<>)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime();
            });

        /// <summary>
        /// Добавление обработчика <see cref="IPipelineBehavior{TRequest, TResponse}"/>.
        /// </summary>
        /// <param name="services">Коллекция сервисов</param>
        /// <returns><see cref="IServiceCollection"/></returns>
        private static IServiceCollection AddPipelineBehavior(this IServiceCollection services) => services
            .Scan(scan =>
            {
                scan
                    .FromAssemblies(Assembly.Load(ApplicationProjectNameSpace))
                    .AddClasses(classes => classes
                        .AssignableTo(typeof(IPipelineBehavior<,>)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime();
            });
    }
}
