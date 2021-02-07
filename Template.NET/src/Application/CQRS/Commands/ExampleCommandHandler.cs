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

        /// <summary>Initializes a new instance of the <see cref="ExampleCommandHandler"/> class.</summary>
        /// <param name="logger"><see cref="ILogger{TCategoryName}"/></param>
        public ExampleCommandHandler(ILogger<ExampleCommandHandler> logger)
        {
            _logger = logger;
        }

        /// <inheritdoc />
        protected override Task Handle(ExampleCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            try
            {
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