using Domain.Common;
using System;

namespace Domain.Example.Entities
{
    /// <summary>Пример доменной сущности</summary>
    public class ExampleEntity
    {
        private readonly IEventBus _eventBus;

        /// <summary>Initializes a new instance of the <see cref="ExampleEntity"/> class.</summary>
        /// <param name="eventBus"><see cref="IEventBus"/></param>
        public ExampleEntity(IEventBus eventBus)
        {
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }
    }
}