using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ExampleContext.Application.Queries
{
    /// <inheritdoc />
    public class ExampleQueryHandler : IRequestHandler<ExampleQuery, ExampleQueryResult>
    {
        private readonly ILogger<ExampleQueryHandler> _logger;

        /// <summary>Initializes a new instance of the <see cref="ExampleQueryHandler"/> class.</summary>
        /// <param name="logger"><see cref="ILogger{TCategoryName}"/></param>
        public ExampleQueryHandler(ILogger<ExampleQueryHandler> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc />
        public Task<ExampleQueryResult> Handle(ExampleQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            try
            {
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