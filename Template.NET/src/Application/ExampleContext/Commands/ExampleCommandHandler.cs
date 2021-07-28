using Common.Domain.Services;
using Domain.ExampleContext.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ExampleContext.Commands
{
    /// <inheritdoc />
    public class ExampleCommandHandler : IRequestHandler<ExampleCommand>
    {
        private readonly ILogger<ExampleCommandHandler> _logger;
        private readonly IEventBusService _eventBusService;

        /// <summary>Initializes a new instance of the <see cref="ExampleCommandHandler"/> class.</summary>
        /// <param name="logger"><see cref="ILogger{TCategoryName}"/></param>
        /// <param name="eventBusService"><see cref="IEventBusService"/></param>
        public ExampleCommandHandler(
            ILogger<ExampleCommandHandler> logger,
            IEventBusService eventBusService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _eventBusService = eventBusService ?? throw new ArgumentNullException(nameof(eventBusService));
        }

        /// <inheritdoc />
        public async Task<Unit> Handle(ExampleCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            try
            {
                await _eventBusService.PublishAsync(new ExampleEvent());
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