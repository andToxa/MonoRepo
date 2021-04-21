using Application.Common.Events;
using Domain.Common.Services;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Application.Common.Services
{
    /// <inheritdoc />
    public class EventBusService : IEventBusService
    {
        private readonly IMediator _mediator;

        /// <summary>Initializes a new instance of the <see cref="EventBusService"/> class.</summary>
        /// <param name="mediator"><see cref="IMediator"/></param>
        public EventBusService(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <inheritdoc />
        public async Task PublishAsync<T>(T domainEvent)
        {
            await _mediator.Publish(new Event<T>(domainEvent));
        }
    }
}