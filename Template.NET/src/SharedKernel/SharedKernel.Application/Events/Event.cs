using MediatR;
using System;

namespace SharedKernel.Application.Events
{
    /// <inheritdoc />
    public class Event<T> : INotification
    {
        /// <summary>Initializes a new instance of the <see cref="Event{T}"/> class.</summary>
        /// <param name="data">Данные доменного события</param>
        public Event(T data)
        {
            Data = data ?? throw new ArgumentNullException(nameof(data));
        }

        /// <summary>Данные доменного события</summary>
        public T Data { get; }
    }
}