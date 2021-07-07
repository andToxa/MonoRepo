using Domain.Common.Services;
using System;

namespace Domain.ExampleContext.Entities
{
    /// <summary>Пример доменной сущности</summary>
    public class ExampleEntity
    {
        private readonly IEventBusService _eventBusService;

        /// <summary>Initializes a new instance of the <see cref="ExampleEntity"/> class.</summary>
        /// <param name="eventBusService"><see cref="IEventBusService"/></param>
        public ExampleEntity(IEventBusService eventBusService)
        {
            _eventBusService = eventBusService ?? throw new ArgumentNullException(nameof(eventBusService));
        }
    }
}