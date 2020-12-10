using MediatR;
using System;

namespace Application.Common.CQRS.Events
{
    /// <inheritdoc />
    public class GenericEvent<T> : INotification
    {
        /// <summary>Initializes a new instance of the <see cref="GenericEvent{T}"/> class.</summary>
        /// <param name="data">Данные доменного события</param>
        public GenericEvent(T data)
        {
            DomainEvent = data ?? throw new ArgumentNullException(nameof(data));
        }

        /// <summary>Данные доменного события</summary>
        public T DomainEvent { get; }
    }
}