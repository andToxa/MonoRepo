using MediatR;
using Microsoft.Extensions.Logging;
using SharedKernel.Application.Events;
using SharedKernel.Domain.Services;
using System;
using System.Threading.Tasks;

namespace SharedKernel.Application.Services
{
    /// <inheritdoc />
    public class EventBusService : IEventBusService
    {
        private readonly IMediator _mediator;
        private readonly ILogger<EventBusService> _logger;

        /// <summary>Initializes a new instance of the <see cref="EventBusService"/> class.</summary>
        /// <param name="mediator"><see cref="IMediator"/></param>
        /// <param name="logger"><see cref="ILogger{TCategoryName}"/></param>
        public EventBusService(
            IMediator mediator,
            ILogger<EventBusService> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc cref="IEventBusService.PublishAsync{T}"/>
        public async Task PublishAsync<T>(T domainEvent)
        {
            await _mediator.Publish(new Event<T>(domainEvent));
            _logger.LogInformation("Event published: {@Event}", domainEvent);
        }
    }
}