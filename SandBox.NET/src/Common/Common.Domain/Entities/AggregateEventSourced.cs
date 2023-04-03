using Common.Domain.Entities.Abstractions;
using Common.Domain.Services;
using Common.Domain.ValueObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Domain.Entities;

/// <inheritdoc />
public class AggregateEventSourced<T> : Entity<T>
{
    private readonly List<IDomainEvent<T>> _events = new();
    private long _version = 0;

    /// <summary>
    /// Конструктор <see cref="AggregateEventSourced{T}"/>
    /// </summary>
    public AggregateEventSourced()
    {
    }

    /// <summary>
    /// Конструктор <see cref="AggregateEventSourced{T}"/>
    /// </summary>
    /// <param name="id"><see cref="Id{T}"/></param>
    public AggregateEventSourced(Id<T> id)
        : base(id)
    {
        // todo play events
    }

    /// <summary>
    /// Конструктор <see cref="AggregateEventSourced{T}"/>
    /// </summary>
    /// <param name="id"><see cref="Id{T}"/></param>
    /// <param name="events">Список <see cref="IDomainEvent{T}"/></param>
    protected AggregateEventSourced(Id<T> id, IEnumerable<IDomainEvent<T>> events)
        : base(id)
    {
        foreach (var @event in events)
        {
            AppendEvent(@event);
        }
    }

    /// <summary>
    /// Загрузка из репозитория
    /// </summary>
    /// <param name="eventStore"><see cref="IEventStore{T}"/></param>
    /// <param name="id"><see cref="Id{T}"/></param>
    /// <returns><see cref="Task{TResult}"/></returns>
    public static async Task<AggregateEventSourced<T>> LoadAsync(IEventStore<T> eventStore, Id<T> id)
    {
        var events = await eventStore.LoadEventsAsync(id);
        var aggregateRoot = new AggregateEventSourced<T>(id, events);

        return aggregateRoot;
    }

    /// <summary>
    /// Сохранение изменений
    /// </summary>
    /// <param name="eventStore"><see cref="IEventStore{T}"/></param>
    /// <returns><see cref="Task{TResult}"/></returns>
    public async Task SaveAsync(IEventStore<T> eventStore)
    {
        await eventStore.SaveEventsAsync(Id, _version, _events);
        _version += _events.Count;
        _events.Clear();
    }

    /// <summary>
    /// Добавление события
    /// </summary>
    /// <param name="event"><see cref="IDomainEvent{T}"/></param>
    public void AppendEvent(IDomainEvent<T> @event)
    {
        _events.Add(@event);
        ((dynamic)this).Apply((dynamic)@event);
    }
}