using Domain.Common;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Application.Common.CQRS.Events
{
    /// <inheritdoc />
    public class GenericEventBus : IEventBus
    {
        private readonly IMediator _mediator;

        /// <summary>Initializes a new instance of the <see cref="GenericEventBus"/> class.</summary>
        /// <param name="mediator"><see cref="IMediator"/></param>
        public GenericEventBus(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <inheritdoc />
        public async Task PublishAsync<T>(T domainEvent)
        {
            await _mediator.Publish(new GenericEvent<T>(domainEvent));
        }
    }
}