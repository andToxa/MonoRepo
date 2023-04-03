using Common.Domain.ValueObjects;

namespace Common.Domain.Entities.Abstractions;

/// <summary>
/// Доменное событие
/// </summary>
/// <typeparam name="T">Тип сущности</typeparam>
public interface IDomainEvent<T>
{
    /// <summary>
    /// Идентификатор события
    /// </summary>
    public Id<IDomainEvent<T>> EventId { get; }

    /// <summary>
    /// Идентификатор сущности
    /// </summary>
    public Id<T> EntityId { get; }
}