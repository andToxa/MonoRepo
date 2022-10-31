using Common.Domain.ValueObjects;

namespace Common.Domain.Entities.Abstractions;

/// <inheritdoc />
public abstract class Entity<T> : IEntity<T>
{
    /// <summary>
    /// Конструктор <see cref="Entity{T}"/>
    /// </summary>
    protected Entity()
    {
        Id = new Id<T>();
    }

    /// <summary>
    /// Конструктор <see cref="Entity{T}"/>
    /// </summary>
    /// <param name="id"><see cref="Id{T}"/></param>
    protected Entity(Id<T> id)
    {
        Id = id;
    }

    /// <inheritdoc />
    public Id<T> Id { get; }
}