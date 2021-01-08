using Domain.Common;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Application.Common.CQRS
{
    /// <inheritdoc />
    public class EventBus : IEventBus
    {
        private readonly IMediator _mediator;

        /// <summary>Initializes a new instance of the <see cref="EventBus"/> class.</summary>
        /// <param name="mediator"><see cref="IMediator"/></param>
        public EventBus(IMediator mediator)
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