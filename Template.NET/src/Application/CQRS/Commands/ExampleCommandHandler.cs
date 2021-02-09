using Domain.Common;
using Domain.Example.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Commands
{
    /// <inheritdoc />
    public class ExampleCommandHandler : AsyncRequestHandler<ExampleCommand>
    {
        private readonly ILogger<ExampleCommandHandler> _logger;
        private readonly IEventBus _eventBus;

        /// <summary>Initializes a new instance of the <see cref="ExampleCommandHandler"/> class.</summary>
        /// <param name="logger"><see cref="ILogger{TCategoryName}"/></param>
        /// <param name="eventBus"><see cref="IEventBus"/></param>
        public ExampleCommandHandler(
            ILogger<ExampleCommandHandler> logger,
            IEventBus eventBus)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }

        /// <inheritdoc />
        protected override Task Handle(ExampleCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            try
            {
                _eventBus.PublishAsync(new ExampleEvent()).ConfigureAwait(false);
                throw new System.NotImplementedException();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error: {Message}", e.Message);
                throw;
            }
        }
    }
}