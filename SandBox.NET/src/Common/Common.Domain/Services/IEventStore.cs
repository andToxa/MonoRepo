using Common.Domain.Entities.Abstractions;
using Common.Domain.ValueObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Domain.Services;

/// <summary>
/// Репозиторий агрегатов
/// </summary>
/// <typeparam name="T">Тип сущности</typeparam>
public interface IEventStore<T>
{
    /// <summary>
    /// Восстановление событий
    /// </summary>
    /// <param name="id"><see cref="Id{T}"/></param>
    /// <returns>Список <see cref="IDomainEvent{T}"/></returns>
    public Task<IEnumerable<IDomainEvent<T>>> LoadEventsAsync(Id<T> id);

    /// <summary>
    /// Сохранение событий
    /// </summary>
    /// <param name="id"><see cref="Id{T}"/></param>
    /// <param name="version">Версия агрегата</param>
    /// <param name="objects">Список <see cref="IDomainEvent{T}"/></param>
    /// <returns><see cref="Task{TResult}"/></returns>
    public Task SaveEventsAsync(Id<T> id, long version, IEnumerable<IDomainEvent<T>> objects);
}
