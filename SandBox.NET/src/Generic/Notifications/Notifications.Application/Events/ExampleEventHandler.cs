using Common.Application.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using Notifications.Domain.Events;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Notifications.Application.Events
{
    /// <inheritdoc />
    public class ExampleEventHandler : INotificationHandler<Event<ExampleEvent>>
    {
        private readonly ILogger<ExampleEventHandler> _logger;

        /// <summary>Initializes a new instance of the <see cref="ExampleEventHandler"/> class.</summary>
        /// <param name="logger"><see cref="ILogger{TCategoryName}"/></param>
        public ExampleEventHandler(ILogger<ExampleEventHandler> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc />
        public Task Handle(Event<ExampleEvent> notification, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            try
            {
                _logger.LogInformation("{Event}", notification.Data.ToString());
                throw new NotImplementedException();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error: {Message}", e.Message);
                throw;
            }
        }
    }
}